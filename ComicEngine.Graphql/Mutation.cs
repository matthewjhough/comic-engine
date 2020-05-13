using System.Threading.Tasks;
using ComicEngine.Api.Client;
using ComicEngine.Common.Comic;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql {
    public class Mutation {
        private readonly ILogger _logger;

        private IComicRepository _comicApiService;

        public Mutation (ILogger<Mutation> logger, IComicRepository comicApiService) {
            _logger = logger ??
                throw new System.ArgumentNullException (nameof (logger));
            _comicApiService = comicApiService ??
                throw new System.ArgumentNullException (nameof (comicApiService));
        }

        public async Task<Comic> CreateSavedComic (IResolverContext context) {
            var comicInput = context.Argument<Comic> ("comic");

            if (comicInput is null) {
                throw new System.ArgumentNullException (nameof (comicInput));
            }

            _logger.LogDebug ("Executing mutation with comic titled: {title}", comicInput.Title);

            Comic response = await _comicApiService.SaveComicToApi (comicInput);

            return response;
        }
    }
}