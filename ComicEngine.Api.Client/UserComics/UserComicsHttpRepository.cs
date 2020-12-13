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

namespace ComicEngine.Api.Client.UserComics
{
    public class UserComicsHttpRepository : IUserComicsHttpRepository
    {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (UserComicsHttpRepository));
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
        public UserComicsHttpRepository (
            ComicEngineApiConfiguration config, 
            IHttpContextAccessor httpContextAccessor, 
            TokenClientSettings tokenClientSettings) {
            _comicApiConfig = config;
            _httpContextAccessor = httpContextAccessor;
            _tokenClientSettings = tokenClientSettings;
        }

        /// <summary>
        /// Retrieves all comics associated with a user.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserComic>> RequestAllUserComics (string userId) {
            var fullUrl = $"{_comicApiConfig.ClientBaseUrl}/{EndpointsV1.UserComicsEndpointBase}/{userId}";
            
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
            
            var fullUrl = $"{_comicApiConfig.ClientBaseUrl}/{EndpointsV1.UserComicsEndpointBase}/{userId}";
            
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
        /// Implements <see cref="IUserComicsHttpRepository.DeleteUserComic"/>
        /// </summary>
        public async Task<bool> DeleteUserComic(string userComicId, string userId)
        {
            var fullUrl = $"{_comicApiConfig.ClientBaseUrl}/{EndpointsV1.UserComicsEndpointBase}/{userId}/comic/{userComicId}";
            
            Logger.LogDebug ("Making request to: {endpoint}", fullUrl);
            
            var client = new HttpRequestClientBuilder<bool>()
                .WithAbsoluteUrl(fullUrl)
                .WithRequestMethod(HttpMethod.Delete)
                .WithHttpContextAccessor(_httpContextAccessor)
                .WithTokenClientSettings(_tokenClientSettings)
                .Build();
            
            var isComicDeleted = await client.Send();
            
            return isComicDeleted;
        }
    }
}