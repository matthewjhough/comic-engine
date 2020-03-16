using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Graphql.ComicEngineApi;
using ComicEngine.Graphql.Graphql.Types;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Graphql {
    public class Mutation {
        private readonly ILogger _logger;

        private IComicEngineApiService _comicApiService;

        public Mutation (ILogger<Mutation> logger, IComicEngineApiService comicApiService) {
            _logger = logger;
            _comicApiService = comicApiService;
        }

        public async Task<Comic> CreateSavedComic (ComicInput comic) {
            _logger.LogDebug ("Executing mutation with comic titled: {title}", comic.Title);

            Comic response = await _comicApiService.SaveComicToApi (comic);

            return response;
        }
    }
}