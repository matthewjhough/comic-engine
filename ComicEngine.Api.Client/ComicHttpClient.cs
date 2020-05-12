using System;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Common;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client {
    public class ComicHttpClient : BaseHttpClient {
        public readonly string _comicEngineApiUri;
        private readonly ILogger _logger = ApplicationLogging.CreateLogger (nameof (ComicHttpClient));

        public ComicHttpClient (
            ComicHttpClientConfig apiConfig
        ) {
            _comicEngineApiUri = apiConfig?.ComicHttpClientUrl;
        }

        /// <summary>
        /// Creates an Http request to the Api server.
        /// </summary>
        /// <param name="endpoint">Full path of Api preffered route</param>
        /// <param name="parameters">(OPTIONAL) Query string parameters to send to Api</param>
        /// <returns><see cref="string" /></returns>
        public async Task<T> RequestComicFromApi<T> (string endpoint, string parameters = "") {
            // TODO: Add logging
            if (string.IsNullOrWhiteSpace (_comicEngineApiUri)) {
                throw new Exception ("Api Url was null or whitespace.");
            }
            var response = await base.MakeRequest<T> (HttpMethod.Get, $"{_comicEngineApiUri}/{endpoint}?{parameters}");
            _logger.LogDebug ("RequestComicFromApi response: ", response);

            return response;
        }

        /// <summary>
        /// Creates an Http request to the Api server.
        /// </summary>
        /// <param name="endpoint">Full path of Api preffered route</param>
        /// <param name="parameters">(OPTIONAL) Query string parameters to send to Api</param>
        /// <returns><see cref="string" /></returns>
        public async Task<T> PostComicToApi<T> (string endpoint, string parameters) {
            // TODO: Add logging
            if (string.IsNullOrWhiteSpace (_comicEngineApiUri)) {
                throw new Exception ("Api Url was null or whitespace.");
            }

            var response = await base.MakeRequest<T> (HttpMethod.Post, $"{_comicEngineApiUri}/{endpoint}?{parameters}");
            _logger.LogDebug ("PostComicToApi response: ", response);

            return response;
        }
    }
}