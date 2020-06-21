using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client {
    public class ComicHttpRepository : IComicHttpRepository {
        private const string MarvelEndpoint = "v1/marvel/comic";
        private const string SavedComicsEndpoint = "v1/saved/comics";
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (ComicHttpRepository));
        private readonly ComicHttpClientConfig _comicApiClientConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Repository for interacting with the Comic Engine Comic API
        /// </summary>
        /// <param name="config"><see cref="ComicHttpClientConfig"/> pulled
        /// from the appsettings.</param>
        /// <param name="httpContextAccessor"></param>
        public ComicHttpRepository (ComicHttpClientConfig config, 
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

        /// <summary>
        /// Sends UPC barcode value to marvel api, and returns matching comic.
        /// </summary>
        /// <param name="upc">The value in upc format, obtained from barcode.</param>
        /// <returns><see cref="Comic"/></returns>
        public async Task<Comic> RequestMarvelComicByUpc (
            string upc
        ) {
            var parameters = $"upc={upc}";
            var apiClient = new ComicHttpClient(_comicApiClientConfig, _httpContextAccessor);
            Logger.LogDebug ("Making request to: {endpoint}, with parameters: {parameters}", MarvelEndpoint, parameters);
            var comicResponse = await apiClient.RequestComicFromApi<Comic> (MarvelEndpoint, parameters);
            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
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
            var endpoint = $"{MarvelEndpoint}/search";
            var parameters = $"title={title}&issueNumber={issueNumber}";
            var apiClient = new ComicHttpClient(_comicApiClientConfig, _httpContextAccessor);
            Logger.LogDebug ("Making request to: {endpoint} with parameters: {parameters}", endpoint, parameters);
            var comicResponse = await apiClient.RequestComicFromApi<IEnumerable<Comic>> (endpoint, parameters);
            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return comicResponse;
        }

        /// <summary>
        /// Saves a <see cref="Comic"/> to the users saved comics.
        /// </summary>
        /// <param name="comic">The <see cref="Comic"/> to be saved to the user's collection</param>
        /// <returns><see cref="Comic"/></returns>
        public async Task<Comic> SaveComicToApi (Comic comic) {
            Logger.LogDebug ("Making request to: {endpoint}", SavedComicsEndpoint);
            var apiClient = new ComicHttpClient (_comicApiClientConfig, _httpContextAccessor);
            var fullUrl = $"{apiClient.ComicEngineApiUri}/{SavedComicsEndpoint}";
            var comicResponse = await apiClient.PostToApiWithBody(fullUrl, comic);

            Logger.LogDebug ("Response returned: {response}", comicResponse);

            return null;
        }
    }
}