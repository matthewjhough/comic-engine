using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Identity.Client;
using ComicEngine.Shared;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Api.Client {
    //TODO: Make requests to server in here instead of the client, add builder for this repo.
    public class ComicHttpRepository : IComicHttpRepository {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (ComicHttpRepository));
        private readonly ComicHttpClientConfig _comicApiClientConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenClientSettings _tokenClientSettings;

        /// <summary>
        /// Repository for interacting with the Comic Engine Comic API
        /// </summary>
        /// <param name="config"><see cref="ComicHttpClientConfig"/> pulled
        /// from the appsettings.</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="tokenClientSettings"></param>
        public ComicHttpRepository (
                ComicHttpClientConfig config, 
                IHttpContextAccessor httpContextAccessor, 
                TokenClientSettings tokenClientSettings) {
            _comicApiClientConfig = config;
            _httpContextAccessor = httpContextAccessor;
            _tokenClientSettings = tokenClientSettings;
        }

        /// <summary>
        /// Retrieves all comics associated with a user.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserComic>> RequestAllUserComics (string userId) {
            var fullUrl = $"{_comicApiClientConfig.ComicHttpClientUrl}/{EndpointsV1.UserComicsEndpointBase}/{userId}";
            
            Logger.LogDebug ("Making request to: {endpoint}", fullUrl);
            
            var client = new HttpRequestClientBuilder<object>()
                .WithRequestMethod(HttpMethod.Get)
                .WithAbsoluteUrl(fullUrl)
                .WithHttpContextAccessor(_httpContextAccessor)
                .WithTokenClientSettings(_tokenClientSettings)
                .Build();
            
            var response = await client.Send();
            var comicResponseString = response.ToString();
            var comicResponse = JsonConvert
                .DeserializeObject<IEnumerable<UserComic>>(comicResponseString);

            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
        }
        
        /// <summary>
        /// Saves a <see cref="Comic"/> to the users saved comics.
        /// </summary>
        /// <param name="comic">The <see cref="Comic"/> to be saved to the user's collection</param>
        /// <param name="userId">The id or subject of the user making the request.</param>
        /// <returns><see cref="Comic"/></returns>
        public async Task<UserComic> SaveComicToApi (Comic comic, string userId) {
            
            var fullUrl = $"{_comicApiClientConfig.ComicHttpClientUrl}/{EndpointsV1.UserComicsEndpointBase}/{userId}";
            
            Logger.LogDebug ("Making request to: {endpoint}", fullUrl);
            
            var client = new HttpRequestClientBuilder<object>()
                .WithAbsoluteUrl(fullUrl)
                .WithRequestBody(comic)
                .WithRequestMethod(HttpMethod.Post)
                .WithHttpContextAccessor(_httpContextAccessor)
                .WithTokenClientSettings(_tokenClientSettings)
                .Build();
            
            object response = await client.Send();
            var comicResponse = JsonConvert.DeserializeObject<UserComic>(response.ToString());

            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
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
                var absoluteUrl = $"{_comicApiClientConfig.ComicHttpClientUrl}/{_comicApiClientConfig.ComicHttpClientUrl}?{parameters}";
                
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
                    _comicApiClientConfig.ComicHttpClientUrl);
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
                var absoluteUrl = $"{_comicApiClientConfig.ComicHttpClientUrl}/{endpoint}?{parameters}";
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
                    _comicApiClientConfig.ComicHttpClientUrl);
                throw;
            }
        }
    }
}