using System;
using System.Collections.Generic;
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
        private MarvelApiConfig _marvelApiSettings;

        private readonly ILogger _logger;

        private readonly IHttpClientFactory _clientFactory;

        public MarvelHttpClientV1 (
            IHttpClientFactory clientFactory,
            ILogger<MarvelHttpClientV1> logger,
            MarvelApiConfig marvelApiSettings
        ) {
            _clientFactory = clientFactory;
            _logger = logger;
            _marvelApiSettings = marvelApiSettings;
        }

        // todo: move to service layer
        /// <summary>
        /// Helper method to take care of repeat mapping logic.
        /// </summary>
        /// <param name="marvelComic"></param>
        /// <returns>Comic POCO</returns>
        public Comic MapResponseToComic (MarvelComic marvelComic, string copyright) {
            try {
                return new Comic () {
                    Id = marvelComic.Id,
                        Copyright = copyright,
                        IssueNumber = marvelComic.IssueNumber,
                        Title = marvelComic.Title,
                        Upc = marvelComic.Upc,
                        Description = marvelComic.Description,
                        Characters = marvelComic.Characters.Items.ToList (),
                        Creators = marvelComic.Creators.Items.ToList (),
                        Series = marvelComic.ComicSeries,
                        PublishDates = marvelComic.Dates.ToList (),
                        PageCount = marvelComic.PageCount,
                        ResourceUri = marvelComic.ResourceUri,
                        Thumbnail = $"{marvelComic.Thumbnail.Path}.{marvelComic.Thumbnail.Extension}",
                        RelevantLinks = marvelComic.Urls
                };
                // todo: implement custom error handling
            } catch (Exception ex) {
                throw new Exception ("An error occured mapping marvel comic");
            }
        }

        // todo: Move to service layer

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
            }

            return new MarvelResponse ();
        }

        // todo: Move to service layer

        /// <summary>
        /// Fetches matching comic based on barcode isbn number.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public async Task<Comic> GetByCode (string upc) {
            HttpRequestMessage request = CreateRequestMessage ("/comics", $"upc={upc}");

            MarvelResponse comicResponse = await RequestComic (request, "marvelByCode");
            MarvelComic comicData = comicResponse
                .Data
                .Results
                .FirstOrDefault ();

            if (comicData is null) {
                return new Comic ();
            }

            Comic comic = MapResponseToComic (comicData, comicResponse.Copyright);

            return comic;
        }

        // todo: Move to service layer.
        async public Task<IList<Comic>> GetByTitleAndIssueNumber (string title, string issueNumber) {
            var request = CreateRequestMessage (
                "/comics", $"title={title}&issueNumber={issueNumber}"
            );

            MarvelResponse comicResponse = await RequestComic (request, "marvelByTitleIssueNumber");
            IEnumerable<MarvelComic> comicData = comicResponse
                .Data
                .Results.AsEnumerable ();

            if (comicData is null) {
                return new List<Comic> ();;
            }

            var comics = comicData
                .Select (marvelComic =>
                    MapResponseToComic (marvelComic, comicResponse.Copyright))
                .ToList ();

            return comics;
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