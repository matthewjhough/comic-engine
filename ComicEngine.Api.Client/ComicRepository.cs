using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client {
    public class ComicRepository : IComicRepository {
        private const string MarvelEndpoint = "v1/marvel/comic";
        private const string SavedComicsEndpoint = "v1/saved/comics";
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (ComicRepository));
        private readonly ComicHttpClientConfig _comicApiClientConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Repository for interacting with the Comic Engine Comic API
        /// </summary>
        /// <param name="config"><see cref="ComicHttpClientConfig"/> pulled
        /// from the appsettings.</param>
        /// <param name="httpContextAccessor"></param>
        public ComicRepository (ComicHttpClientConfig config, 
            IHttpContextAccessor httpContextAccessor) {
            _comicApiClientConfig = config;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Retrieves all comics associated with a user.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Comic>> RequestAllSavedComics () {
            Logger.LogDebug ("Making request to: {endpoint}", SavedComicsEndpoint);
            var apiClient = new ComicHttpClient(_comicApiClientConfig, _httpContextAccessor);
            
            var comicResponse = await apiClient.RequestComicFromApi<IEnumerable<Comic>> (SavedComicsEndpoint);
            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
        }

        public async Task<Comic> RequestMarvelComicByUpc (
            string upc
        ) {
            string parameters = $"upc={upc}";
            var apiClient = new ComicHttpClient(_comicApiClientConfig, _httpContextAccessor);
            Logger.LogDebug ("Making request to: {endpoint}, with parameters: {parameters}", MarvelEndpoint, parameters);
            var comcResponse = await apiClient.RequestComicFromApi<Comic> (MarvelEndpoint, parameters);
            Logger.LogDebug ("Response returned: {response}", comcResponse);

            return comcResponse;
        }

        public async Task<IEnumerable<Comic>> RequestMarvelComicsByParameters (
            string title, string issueNumber
        ) {
            string endpoint = $"{MarvelEndpoint}/search";
            string parameters = $"title={title}&issueNumber={issueNumber}";
            var apiClient = new ComicHttpClient(_comicApiClientConfig, _httpContextAccessor);
            Logger.LogDebug ("Making request to: {endpoint} with parameters: {parameters}", endpoint, parameters);
            var comicResponse = await apiClient.RequestComicFromApi<IEnumerable<Comic>> (endpoint, parameters);
            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
        }

        public async Task<Comic> SaveComicToApi (Comic comic) {
            Logger.LogDebug ("Making request to: {endpoint}", SavedComicsEndpoint);
            var apiClient = new ComicHttpClient (_comicApiClientConfig, _httpContextAccessor);
            string fullUrl = $"{apiClient.ComicEngineApiUri}/{SavedComicsEndpoint}";

            var comicResponse = await apiClient.MakeRequestWithBody<Comic> (fullUrl, comic);

            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return null;
        }
    }
}