using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Client.ComicEngineApi.HttpClient {
    public class ComicHttpClient : BaseHttpClient, IComicHttpClient {
        private readonly string _comicEngineApiUri;
        private readonly ILogger _logger;

        public ComicHttpClient (
            ILogger<ComicHttpClient> logger,
            IHttpClientFactory clientFactory,
            ComicHttpClientConfig apiConfig
        ) {
            _logger = logger;
            _comicEngineApiUri = apiConfig?.ComicHttpClientUrl;
        }

        /// <summary>
        /// Creates an Http request to the Api server.
        /// </summary>
        /// <param name="endpoint">Full path of Api preffered route</param>
        /// <param name="parameters">(OPTIONAL) Query string parameters to send to Api</param>
        /// <returns><see cref="string" /></returns>
        public async Task<T> RequestComicFromApi<T> (string endpoint, string parameters) {
            // TODO: Add logging
            if (string.IsNullOrWhiteSpace (_comicEngineApiUri)) {
                throw new Exception ("Api Url was null or whitespace.");
            }

            var response = await base.MakeRequest<T> (HttpMethod.Get, $"{_comicEngineApiUri}/{endpoint}?{parameters}");
            _logger.LogDebug ("RequestComicFromApi response: ", response);

            return response;
        }
    }
}