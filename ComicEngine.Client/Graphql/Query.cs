using System;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Client.Graphql {
    public class Query {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger _logger;
        private readonly string ComicEngineApi = "http://localhost:6002";

        public Query (IHttpClientFactory clientFactory, ILogger<Query> logger) {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<BasicComic> BasicComic (string upc) {
            try {
                _logger.LogDebug ("Fetching marvel comic with upc: {upc}", upc);

                HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Get,
                    $"{ComicEngineApi}/marvel/comic?upc={upc}");

                HttpClient client = _clientFactory.CreateClient ("comics");
                request.Headers.Add ("Accept", "*/*");
                request.Headers.Add ("Sec-Fetch-Mode", "cors");

                HttpResponseMessage response = await client.SendAsync (request);

                if (response.IsSuccessStatusCode) {
                    _logger.LogDebug ("Response Message Header \n\n" + response.Content.Headers + "\n");
                    // Get the response
                    string comicJsonString = await response.Content.ReadAsStringAsync ();
                    _logger.LogDebug ("Comic data returned: {comicData}", comicJsonString);

                    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                    BasicComic deserializedComic = JsonConvert.DeserializeObject<BasicComic> (comicJsonString);
                    // Do something with it
                    return deserializedComic;
                }

                return new BasicComic { };
            } catch (Exception exception) {
                _logger.LogDebug (exception, "Request not send to ComicEngine API.");
                _logger.LogDebug ("Base URL attempted: {comicEngineApi}", ComicEngineApi);

                return new BasicComic { };
            }

        }
    }
}