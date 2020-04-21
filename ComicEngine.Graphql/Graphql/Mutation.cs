using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Graphql.ComicEngineApi;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Graphql {
    public class Mutation {
        private readonly ILogger _logger;

        private IComicEngineApiRepository _comicApiService;

        public Mutation (ILogger<Mutation> logger, IComicEngineApiRepository comicApiService) {
            _logger = logger;
            _comicApiService = comicApiService;
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