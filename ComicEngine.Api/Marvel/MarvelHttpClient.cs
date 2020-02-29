using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using ComicEngine.Common.Marvel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Api.Marvel {
    public class MarvelHttpClient : BaseHttpClient {
        private MarvelApiConfig _marvelApiSettings;

        private readonly ILogger _logger;

        private readonly IHttpClientFactory _clientFactory;

        public MarvelHttpClient (
            ILogger<MarvelHttpClient> logger,
            MarvelApiConfig marvelApiSettings
        ) {
            _logger = logger;
            _marvelApiSettings = marvelApiSettings;
        }

        /// <summary>
        /// Sends an HTTP request to get comic(s)
        /// </summary>
        /// <returns></returns>
        public async Task<MarvelResponse> RequestComic (string route, string query) {
            string url = CreateRequestUrl (route, query);
            MarvelResponse response = await base.MakeRequest<MarvelResponse> (HttpMethod.Get, url);

            return response;
        }

        /// <summary>
        /// Helper method to create the marvel hash string
        /// </summary>
        /// <param name="route">The marvel api route intended to send a request</param>
        /// <param name="query">The search/query parameters to filter by (query string param format)</param>
        /// <returns></returns>
        private string CreateRequestUrl (string route, string query) {
            string ts = "1";
            string apiHashSource = ts + _marvelApiSettings.PrivateKey + _marvelApiSettings.PublicKey;
            string marvelHash = "1234";

            try {
                using (MD5 md5Hash = MD5.Create ()) {
                    marvelHash = HashUtilities.GetMd5Hash (md5Hash, apiHashSource);
                }
            } catch (Exception exception) {
                throw exception;
            }

            var url = $"{_marvelApiSettings.BaseUrl}{route}?{query}&ts={ts}&apikey={_marvelApiSettings.PublicKey}&hash={marvelHash}";

            return url;
        }
    }
}