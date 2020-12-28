using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Client.Comics;
using ComicEngine.Api.Client.StorageContainers;
using ComicEngine.Api.Client.UserComics;
using ComicEngine.Data.StorageContainers;
using ComicEngine.Shared;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.StorageContainers;
using ComicEngine.Shared.UserComics;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Server.Impl {
    public class Query {
        private readonly ILogger _logger = ApplicationLogging.CreateLogger (nameof (Query));

        private readonly IComicHttpRepository _comicHttpRepository;
        
        private readonly IUserComicsHttpRepository _userComicsHttpRepository;

        private readonly IStorageContainerHttpRepository _storageContainersRepository;

        public Query (
            IComicHttpRepository comicHttpApiService, 
            IUserComicsHttpRepository userComicsHttpRepository,
            IStorageContainerHttpRepository storageContainersRepository) {
            _comicHttpRepository = comicHttpApiService ??
                throw new ArgumentNullException (nameof (comicHttpApiService));
            _userComicsHttpRepository = userComicsHttpRepository ??
                throw new ArgumentNullException(nameof(userComicsHttpRepository));
            _storageContainersRepository = storageContainersRepository ??
                throw new ArgumentNullException(nameof(storageContainersRepository));
        }

        public async Task<Comic> ComicByUpc (string upc) {
            _logger.LogDebug ("Executing query with parameter: {param}", upc);

            Comic response = await _comicHttpRepository.RequestMarvelComicByUpc (upc);

            return response;
        }

        public async Task<IEnumerable<Comic>> ComicsByTitleAndIssueNumber (string title, string issueNumber) {
            _logger.LogDebug ("Executing ComicByTitleAndIssueNumber with parameters: {title}, {issueNumber}", title, issueNumber);

            IEnumerable<Comic> comics = await _comicHttpRepository
                .RequestMarvelComicsByParameters (title, issueNumber);
            
            var comicsByTitleAndIssueNumber = comics as Comic[] ?? comics.ToArray();
            
            _logger.LogDebug(
                "'{comicsCount}' found with search criteria '{title}', 'issueNumber'", 
                comicsByTitleAndIssueNumber?.Count(),
                title,
                issueNumber
                );
            return comicsByTitleAndIssueNumber;
        }

        public async Task<IEnumerable<UserComic>> UserComics (string userId)
        {
            _logger.LogDebug("Retrieving saved comics for user '{userId}'", userId);
            IEnumerable<UserComic> response = await _userComicsHttpRepository.RequestAllUserComics (userId);
            var userComics = response as UserComic[] ?? response.ToArray();
            _logger.LogDebug(
                "Found '{comicCount}' comics for user '{userId}'", 
                userComics.Count(), 
                userId);

            return userComics;
        }

        public async Task<IEnumerable<StorageContainer>> StorageContainers(string userId)
        {
            IEnumerable<StorageContainer> storageContainers = await _storageContainersRepository
                    .GetStorageContainers(userId);

            return storageContainers;
        }
    }
}