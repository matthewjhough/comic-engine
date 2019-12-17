using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ComicEngine.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Api.Marvel {
    public class MarvelHttpClientV1 : IMarvelHttpClient {
        private MarvelApi _marvelApiSettings;

        private readonly ILogger _logger;

        private readonly IHttpClientFactory _clientFactory;

        public MarvelHttpClientV1 (
            IHttpClientFactory clientFactory,
            ILogger<MarvelHttpClientV1> logger,
            MarvelApi marvelApiSettings
        ) {
            _clientFactory = clientFactory;
            _logger = logger;
            _marvelApiSettings = marvelApiSettings;
        }

        /// <summary>
        /// Fetches all comics from marvels api with pagination.
        /// </summary>
        /// <returns></returns>
        public async Task<MarvelResponse> GetAllComics () {
            HttpRequestMessage request = CreateRequestMessage ("/comics", "");
            var client = _clientFactory.CreateClient ("marvel");
            var response = await client.SendAsync (request);

            if (response.IsSuccessStatusCode) {
                var responseStream = await response.Content.ReadAsStreamAsync ();
                var serializer = new JsonSerializer ();

                using (StreamReader reader = new StreamReader (responseStream))
                using (var jsonTextReader = new JsonTextReader (reader)) {
                    return serializer.Deserialize<MarvelResponse> (jsonTextReader);
                }
            } else {
                return new MarvelResponse ();
            }
        }

        /// <summary>
        /// Fetches matching comic based on barcode isbn number.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public async Task<BasicComic> GetByCode (string upc) {
            HttpRequestMessage request = CreateRequestMessage ("/comics", $"upc={upc}");

            MarvelResponse comicResponse = await RequestComic (request, "marvelByCode");
            MarvelComic comicData = comicResponse?
                .Data?
                .Results?
                .FirstOrDefault ();

            if (comicData is null) return new BasicComic ();

            BasicComic comic = new BasicComic () {
                Title = comicData?.Title,
                Upc = comicData?.Upc,
                IssueNumber = (double) comicData?.IssueNumber,
                Description = comicData?.Description
            };

            return comic;
        }

        /// <summary>
        /// Sends an HTTP request to get comic(s)
        /// </summary>
        /// <returns></returns>
        public async Task<MarvelResponse> RequestComic (HttpRequestMessage request, string clientName) {
            var client = _clientFactory.CreateClient (clientName);
            var response = await client.SendAsync (request);

            if (response.IsSuccessStatusCode) {
                var responseStream = await response.Content.ReadAsStreamAsync ();
                var serializer = new JsonSerializer ();

                using (StreamReader reader = new StreamReader (responseStream))
                using (var jsonTextReader = new JsonTextReader (reader)) {
                    return serializer.Deserialize<MarvelResponse> (jsonTextReader);
                }
            } else {
                return new MarvelResponse ();
            }
        }

        /// <summary>
        /// Helper method to reduce duplicate logic when creating a marvel request.
        /// </summary>
        /// <param name="route">The marvel api route intended to send a request</param>
        /// <param name="query">The search/query parameters to filter by (query string param format)</param>
        /// <returns></returns>
        private HttpRequestMessage CreateRequestMessage (string route, string query) {
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

            var requestMessage = new HttpRequestMessage (HttpMethod.Get,
                $"{_marvelApiSettings.BaseUrl}{route}?{query}&ts={ts}&apikey={_marvelApiSettings.PublicKey}&hash={marvelHash}");

            requestMessage.Headers.Add ("Accept", "*/*");
            requestMessage.Headers.Add ("Sec-Fetch-Mode", "cors");

            return requestMessage;
        }

    }
}