using System;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Identity.Client;
using ComicEngine.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client {
    public class ComicHttpClient {
        public readonly string ComicEngineApiUri;
        private readonly ILogger _logger = ApplicationLogging.CreateLogger (nameof (ComicHttpClient));
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly TokenClientSettings _tokenClientSettings;

        // TODO: remove this client entirely
        public ComicHttpClient (
            ComicHttpClientConfig apiConfig,
            IHttpContextAccessor httpContextAccessor,
            TokenClientSettings tokenClientSettings
        ) {
            ComicEngineApiUri = apiConfig?.ComicHttpClientUrl;
            _contextAccessor = httpContextAccessor;
            _tokenClientSettings = tokenClientSettings;
        }

        /// <summary>
        /// Creates an Http request to the Api server.
        /// </summary>
        /// <param name="endpoint">Full path of Api preffered route</param>
        /// <param name="parameters">(OPTIONAL) Query string parameters to send to Api</param>
        /// <returns><see cref="string" /></returns>
        public async Task<T> RequestComicFromApi<T> (string endpoint, string parameters = "") {
            // TODO: Add logging
            if (string.IsNullOrWhiteSpace (ComicEngineApiUri)) {
                throw new Exception ("Api Url was null or whitespace.");
            }

            try
            {
                var absoluteUrl = $"{ComicEngineApiUri}/{endpoint}?{parameters}";
                _logger.LogDebug ("making request to {endpoint}", absoluteUrl);
                var client = new HttpRequestClientBuilder<T>()
                    .WithRequestMethod(HttpMethod.Get)
                    .WithAbsoluteUrl(absoluteUrl)
                    .WithHttpContextAccessor(_contextAccessor)
                    .WithTokenClientSettings(_tokenClientSettings)
                    .Build();

                var response = await client.Send();
                _logger.LogDebug ("{endpoint} response: {response}", absoluteUrl, response);

                return response;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e, "Exception thrown while trying to make request to {comicEngineUri}.", ComicEngineApiUri);
                throw;
            }
        }
    }
}