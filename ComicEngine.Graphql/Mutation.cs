using System;
using System.Threading.Tasks;
using ComicEngine.Api.Client.StorageContainers;
using ComicEngine.Api.Client.UserComics;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.StorageContainers;
using ComicEngine.Shared.UserComics;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql {
    public class Mutation {
        private readonly ILogger _logger;

        private readonly IUserComicsHttpRepository _comicApiRepository;

        private readonly IStorageContainerHttpRepository _storageContainerHttpRepository;

        public Mutation (
            ILogger<Mutation> logger, 
            IUserComicsHttpRepository comicHttpApiService, 
            IStorageContainerHttpRepository storageContainerHttpRepository) {
            _logger = logger ??
                throw new ArgumentNullException (nameof (logger));
            _comicApiRepository = comicHttpApiService ??
                throw new ArgumentNullException (nameof (comicHttpApiService));
            _storageContainerHttpRepository = storageContainerHttpRepository ??
                throw new ArgumentNullException(nameof(storageContainerHttpRepository));
        }

        public async Task<UserComic> CreateUserComic (IResolverContext context)
        {
            Comic comicInput = context.Argument<Comic> ("comic");
            string userId = context.Argument<string> ("userId");

            if (comicInput is null) {
                throw new System.ArgumentNullException (nameof (comicInput));
            }

            _logger.LogDebug ("Executing mutation with comic titled: {title}", comicInput.Title);

            UserComic response = await _comicApiRepository.SaveComicToApi (comicInput, userId);

            if (response is null)
            {
                throw new CreateComicException($"Unable to add comic {comicInput.Id} for user {userId}");
            }

            return response;
        }

        public async Task<bool> DeleteUserComic(IResolverContext context)
        { 
            string userComicId = context.Argument<string>("userComicId");
            string userId = context.Argument<string>("userId");
            bool isDeleted = await _comicApiRepository.DeleteUserComic(userComicId, userId);
            
            return isDeleted;
        }

        public async Task<StorageContainer> CreateStorageContainer(IResolverContext context)
        {
            var storageContainerArgument = context.Argument<StorageContainer>("storageContainer");

            StorageContainer storageContainer = await _storageContainerHttpRepository
                .CreateStorageContainer(storageContainerArgument);

            _logger.LogDebug("Saved '{storageContainerLabel}' to ComicEngine Api - ID '{storageContainerId}'",
                storageContainer.Label,
                storageContainer.Id);
            
            return storageContainer;
        }
    }
}