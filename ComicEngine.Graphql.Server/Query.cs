using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Server {
    public class Query {
        private readonly ILogger _logger = ApplicationLogging.CreateLogger (nameof (Query));

        private readonly IComicHttpRepository _comicHttpRepository;

        public Query (IComicHttpRepository comicHttpApiService) {
            _comicHttpRepository = comicHttpApiService ??
                throw new System.ArgumentNullException (nameof (comicHttpApiService));
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

        public async Task<IEnumerable<Comic>> SavedComics (IResolverContext context)
        {
            IEnumerable<Comic> response = await _comicHttpRepository.RequestAllSavedComics ();

            return response;
        }
    }
}