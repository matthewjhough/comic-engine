using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Api.Client.Comics;
using ComicEngine.Identity.Client.Impl;
using ComicEngine.Shared;
using ComicEngine.Shared.Comics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client.Impl.Comics {
    public class ComicHttpRepository : IComicHttpRepository {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (ComicHttpRepository));
        private readonly ComicEngineApiConfiguration _comicApiConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenClientSettings _tokenClientSettings;

        /// <summary>
        /// Repository for interacting with the Comic Engine Comic API
        /// </summary>
        /// <param name="config"><see cref="ComicEngineApiConfiguration"/> pulled
        /// from the appsettings.</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="tokenClientSettings"></param>
        public ComicHttpRepository (
                ComicEngineApiConfiguration config, 
                IHttpContextAccessor httpContextAccessor, 
                TokenClientSettings tokenClientSettings) {
            _comicApiConfig = config;
            _httpContextAccessor = httpContextAccessor;
            _tokenClientSettings = tokenClientSettings;
        }

        /// <summary>
        /// Sends UPC barcode value to marvel api, and returns matching comic.
        /// </summary>
        /// <param name="upc">The value in upc format, obtained from barcode.</param>
        /// <returns><see cref="Comic"/></returns>
        public async Task<Comic> RequestMarvelComicByUpc (
            string upc
        ) {
            var parameters = $"upc={upc}";
            Logger.LogDebug (
                "Making request to: {endpoint}, with parameters: {parameters}", 
                EndpointsV1.MarvelComicsUpcEndpoint, parameters);
            try
            {
                var absoluteUrl = $"{_comicApiConfig.ClientBaseUrl}/{_comicApiConfig.ClientBaseUrl}?{parameters}";
                
                Logger.LogDebug ("making request to {endpoint}", absoluteUrl);
                
                var client = new HttpRequestClientBuilder<Comic>()
                    .WithRequestMethod(HttpMethod.Get)
                    .WithAbsoluteUrl(absoluteUrl)
                    .WithHttpContextAccessor(_httpContextAccessor)
                    .WithTokenClientSettings(_tokenClientSettings)
                    .Build();

                var comics = await client.Send();
                
                Logger.LogDebug ("{endpoint} response: {response}", absoluteUrl, comics);

                return comics;
            }
            catch (Exception e)
            {
                Logger.LogDebug(e, 
                    "Exception thrown while trying to make request to {comicEngineUri}.", 
                    _comicApiConfig.ClientBaseUrl);
                throw;
            }
        }

        /// <summary>
        /// Makes a request to Marvel api, to find all comics matching title/issue number.
        /// </summary>
        /// <param name="title">The <see cref="Comic"/> title.</param>
        /// <param name="issueNumber">The <see cref="Comic"/> issue number.</param>
        /// <returns><see cref="IEnumerable{Comic}"/></returns>
        public async Task<IEnumerable<Comic>> RequestMarvelComicsByParameters (
            string title, string issueNumber
        ) {
            var endpoint = $"{EndpointsV1.MarvelComicsSearchEndpoint}";
            var parameters = $"title={title}&issueNumber={issueNumber}";
            Logger.LogDebug (
                "Making request to: {endpoint} with parameters: {parameters}", 
                endpoint, 
                parameters);
            
            try
            {
                var absoluteUrl = $"{_comicApiConfig.ClientBaseUrl}/{endpoint}?{parameters}";
                Logger.LogDebug ("making request to {endpoint}", absoluteUrl);
                var client = new HttpRequestClientBuilder<IEnumerable<Comic>>()
                    .WithRequestMethod(HttpMethod.Get)
                    .WithAbsoluteUrl(absoluteUrl)
                    .WithHttpContextAccessor(_httpContextAccessor)
                    .WithTokenClientSettings(_tokenClientSettings)
                    .Build();

                var comics = await client.Send();
                Logger.LogDebug ("{endpoint} response: {response}", absoluteUrl, comics);

                return comics;
            }
            catch (Exception e)
            {
                Logger.LogDebug(e, 
                    "Exception thrown while trying to make request to {comicEngineUri}.", 
                    _comicApiConfig.ClientBaseUrl);
                throw;
            }
        }

    }
}