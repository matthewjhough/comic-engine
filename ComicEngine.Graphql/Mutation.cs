using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Common.Comics;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql {
    public class Mutation {
        private readonly ILogger _logger;

        private readonly IComicHttpRepository _comicHttpApiService;

        public Mutation (ILogger<Mutation> logger, IComicHttpRepository comicHttpApiService) {
            _logger = logger ??
                throw new System.ArgumentNullException (nameof (logger));
            _comicHttpApiService = comicHttpApiService ??
                throw new System.ArgumentNullException (nameof (comicHttpApiService));
        }

        public async Task<Comic> CreateUserComic (IResolverContext context)
        {
            Comic comicInput = context.Argument<Comic> ("comic");
            string userId = context.Argument<string> ("userId");

            if (comicInput is null) {
                throw new System.ArgumentNullException (nameof (comicInput));
            }

            _logger.LogDebug ("Executing mutation with comic titled: {title}", comicInput.Title);

            Comic response = await _comicHttpApiService.SaveComicToApi (comicInput, userId);

            if (response is null)
            {
                throw new CreateComicException($"Unable to add comic {comicInput.Id} for user {userId}");
            }

            return response;
        }
    }
}