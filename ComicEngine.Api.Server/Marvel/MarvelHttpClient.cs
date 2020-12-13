using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ComicEngine.Identity.Client;
using ComicEngine.Shared;
using ComicEngine.Shared.Marvels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Marvel {
    public class MarvelHttpClient {
        private readonly MarvelApiConfig _marvelApiSettings;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public MarvelHttpClient (
            ILogger<MarvelHttpClient> logger,
            MarvelApiConfig marvelApiSettings,
            IHttpContextAccessor httpContextAccessor
        ) {
            _logger = logger;
            _marvelApiSettings = marvelApiSettings;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Sends an HTTP request to get comic(s)
        /// </summary>
        /// <returns></returns>
        public async Task<MarvelResponse> RequestComic (string route, string query) {
            string url = CreateRequestUrl (route, query);
            _logger.LogDebug("Making request to marvel url: {url}", url);
            
            var client = new HttpRequestClientBuilder<MarvelResponse>()
                .WithHttpContextAccessor(_httpContextAccessor)
                .WithRequestMethod(HttpMethod.Get)
                .WithAbsoluteUrl(url)
                .Build();

            var response = await client.Send();

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
            string marvelHash;

            try {
                using (MD5 md5Hash = MD5.Create ()) {
                    marvelHash = HashUtilities.GetMd5Hash (md5Hash, apiHashSource);
                }
            } catch (Exception exception) {
                _logger.LogDebug(exception, "An exception occured while processing the request hash.");
                throw;
            }

            var url = $"{_marvelApiSettings.BaseUrl}{route}?{query}&ts={ts}&apikey={_marvelApiSettings.PublicKey}&hash={marvelHash}";

            return url;
        }
    }
}