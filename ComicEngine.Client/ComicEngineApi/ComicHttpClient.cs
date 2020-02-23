using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Client.ComicEngineApi {
    public class ComicHttpClient : IComicHttpClient {
        private readonly string _comicEngineApiUri;

        private readonly ILogger _logger;

        private readonly IHttpClientFactory _clientFactory;

        public ComicHttpClient (
            ILogger<ComicHttpClient> logger,
            IHttpClientFactory clientFactory,
            ComicHttpClientConfig apiConfig
        ) {
            _logger = logger;
            _clientFactory = clientFactory;
            _comicEngineApiUri = apiConfig?.ComicHttpClientUrl;
        }

        public async Task<string> RequestSerializedComics (
            string parameters,
            string endpoint = ""
        ) {
            if (string.IsNullOrWhiteSpace (_comicEngineApiUri)) {
                throw new Exception ("Api Url was null or whitespace.");
            }

            try {
                _logger.LogDebug ("Fetching marvel comic with parameters: {parameters}", parameters);

                // TODO: Get version from configuration
                HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Get,
                    $"{_comicEngineApiUri}/v1/marvel/comic{endpoint}?{parameters}");

                HttpClient client = _clientFactory.CreateClient ("comics");
                request.Headers.Add ("Accept", "*/*");
                request.Headers.Add ("Sec-Fetch-Mode", "cors");

                HttpResponseMessage response = await client.SendAsync (request);

                if (response.IsSuccessStatusCode) {
                    _logger.LogDebug ("Response Message Header \n\n" + response.Content.Headers + "\n");

                    string comicJsonString = await response.Content.ReadAsStringAsync ();

                    _logger.LogDebug ("Comic data returned: {comicData}", comicJsonString);

                    return comicJsonString;
                }

                return null;
            } catch (Exception exception) {
                _logger.LogDebug (exception, "Request not send to ComicEngine API.");
                _logger.LogDebug ("Base URL attempted: {comicEngineApi}", _comicEngineApiUri);

                throw exception;
            }
        }
    }
}