using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql {
    public class Mutation {
        private readonly ILogger _logger;

        private readonly IComicHttpRepository _comicApiRepository;

        public Mutation (ILogger<Mutation> logger, IComicHttpRepository comicHttpApiService) {
            _logger = logger ??
                throw new System.ArgumentNullException (nameof (logger));
            _comicApiRepository = comicHttpApiService ??
                throw new System.ArgumentNullException (nameof (comicHttpApiService));
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
    }
}