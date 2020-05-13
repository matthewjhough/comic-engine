using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client {
    public class ComicRepository : IComicRepository {
        private readonly string _marvelEndpoint = "v1/marvel/comic";
        private readonly string _savedComicsEndpoint = "v1/saved/comics";
        private ILogger _logger = ApplicationLogging.CreateLogger (nameof (ComicRepository));
        private ComicHttpClient _apiClient;

        public ComicRepository (ComicHttpClientConfig config) {
            _apiClient = new ComicHttpClient (config);
        }

        public async Task<IEnumerable<Comic>> RequestAllSavedComics () {
            _logger.LogDebug ("Making request to: {endpoint}", _savedComicsEndpoint);
            var comicResponse = await _apiClient.RequestComicFromApi<IEnumerable<Comic>> (_savedComicsEndpoint);
            _logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
        }

        public async Task<Comic> RequestMarvelComicByUpc (
            string upc
        ) {
            string parameters = $"upc={upc}";

            _logger.LogDebug ("Making request to: {endpoint}, with parameters: {parameters}", _marvelEndpoint, parameters);
            var comcResponse = await _apiClient.RequestComicFromApi<Comic> (_marvelEndpoint, parameters);
            _logger.LogDebug ("Response returned: {response}", comcResponse);

            return comcResponse;
        }

        public async Task<IEnumerable<Comic>> RequestMarvelComicsByParameters (
            string title, string issueNumber
        ) {
            string endpoint = $"{_marvelEndpoint}/search";
            string parameters = $"title={title}&issueNumber={issueNumber}";

            _logger.LogDebug ("Making request to: {endpoint} with parameters: {parameters}", endpoint, parameters);
            var comicResponse = await _apiClient.RequestComicFromApi<IEnumerable<Comic>> (endpoint, parameters);
            _logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
        }

        public async Task<Comic> SaveComicToApi (Comic comic) {
            _logger.LogDebug ("Making request to: {endpoint}", _savedComicsEndpoint);

            string fullUrl = $"{_apiClient._comicEngineApiUri}/{_savedComicsEndpoint}";

            var comicResponse = await _apiClient.MakeRequestWithBody<Comic> (fullUrl, comic);

            _logger.LogDebug ("Response returned: {response}", comicResponse);

            return null;
        }
    }
}