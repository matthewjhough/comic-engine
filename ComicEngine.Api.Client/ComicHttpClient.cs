using System;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Identity.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client {
    public class ComicHttpClient {
        public readonly string ComicEngineApiUri;
        private readonly ILogger _logger = ApplicationLogging.CreateLogger (nameof (ComicHttpClient));
        private readonly IHttpContextAccessor _contextAccessor;

        public ComicHttpClient (
            ComicHttpClientConfig apiConfig,
            IHttpContextAccessor httpContextAccessor
        ) {
            ComicEngineApiUri = apiConfig?.ComicHttpClientUrl;
            _contextAccessor = httpContextAccessor;
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

            var absoluteUrl = $"{ComicEngineApiUri}/{endpoint}?{parameters}";
            var client = new HttpRequestClientBuilder<T>()
                .WithRequestMethod(HttpMethod.Get)
                .WithAbsoluteUrl(absoluteUrl)
                .WithHttpContextAccessor(_contextAccessor)
                .Build();

            var response = await client.Send();
            
            _logger.LogDebug ("RequestComicFromApi response: ", response);

            return response;
        }

        /// <summary>
        /// Creates an Http request to the Api server.
        /// </summary>
        /// <param name="endpoint">Full path of Api preffered route</param>
        /// <param name="parameters">(OPTIONAL) Query string parameters to send to Api</param>
        /// <returns><see cref="string" /></returns>
        public async Task<T> PostComicToApi<T> (string endpoint, string parameters) {
            // TODO: Add logging
            if (string.IsNullOrWhiteSpace (ComicEngineApiUri)) {
                throw new Exception ("Api Url was null or whitespace.");
            }

            var absoluteUrl = $"{ComicEngineApiUri}/{endpoint}?{parameters}";
            var client = new HttpRequestClientBuilder<T>()
                .WithAbsoluteUrl(absoluteUrl)
                .WithRequestMethod(HttpMethod.Post)
                .WithHttpContextAccessor(_contextAccessor)
                .Build();

            var response = await client.Send();

            _logger.LogDebug ("PostComicToApi response: ", response);

            return response;
        }
        
        /// <summary>
        /// Makes an Http Request with body by accepting an Object of T, serializing it,
        /// and then attaching it to the <see cref="HttpRequestMessage"/> content.
        /// </summary>
        /// <param name="absoluteUrl">The <see cref="string"/> full url.</param>
        /// <param name="obj">The object to be serialized</param>
        /// <typeparam name="T">The Type of the object to be returned.</typeparam>
        /// <returns>Http Response with expected type.</returns>
        public async Task<T> PostToApiWithBody<T> (string absoluteUrl, T obj) 
            where T : class 
        {
            var client = new HttpRequestClientBuilder<T>()
                .WithAbsoluteUrl(absoluteUrl)
                .WithRequestBody(obj)
                .WithRequestMethod(HttpMethod.Post)
                .Build();
            
            var response = await client.Send();

            return response;
        }
    }
}