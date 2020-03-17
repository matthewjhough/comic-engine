using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Graphql.Inputs;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.ComicEngineApi {
    public class ComicEngineApiService : IComicEngineApiService {
        private readonly string _marvelEndpoint = "v1/marvel/comic";
        private readonly string _savedComicsEndpoint = "v1/saved/comics";
        private ILogger _logger;
        private IComicHttpClient _apiClient;

        public ComicEngineApiService (ILogger<ComicEngineApiService> logger, IComicHttpClient apiClient) {
            _logger = logger;
            _apiClient = apiClient;
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

        public async Task<Comic> SaveComicToApi (ComicInput comic) {
            _logger.LogDebug ("Making request to: {endpoint}", _savedComicsEndpoint);
            var parameters = _apiClient.GetQueryString (comic);

            var comicResponse = await _apiClient.PostComicToApi<Comic> (_savedComicsEndpoint, parameters);
            _logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
        }
    }
}