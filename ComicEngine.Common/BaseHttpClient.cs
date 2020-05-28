using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ComicEngine.Common {
    public abstract class BaseHttpClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseHttpClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Sends a basic Http request.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="queryParameters"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        protected async Task<T> MakeRequest<T> (HttpMethod method, string url, string queryParameters = null) {
            var httpClient = new HttpClient ();
            var requestMessage = CreateRequestMessage (method, url);
            var response = await httpClient.SendAsync (requestMessage);

            try {
                if (!response.IsSuccessStatusCode) return default;
                var responseStream = await response.Content.ReadAsStreamAsync ();
                var serializer = new JsonSerializer ();

                using StreamReader reader = new StreamReader (responseStream);
                using var jsonTextReader = new JsonTextReader (reader);
                return serializer.Deserialize<T> (jsonTextReader);
            } catch (Exception) {
                throw new HttpRequestException();
            }
        }

        /// <summary>
        /// Makes an Http Request with body by accepting an Object of T, serializing it,
        /// and then attaching it to the <see cref="HttpRequestMessage"/> content.
        /// </summary>
        /// <param name="fullUrl">The <see cref="string"/> full url.</param>
        /// <param name="obj">The object to be serialized</param>
        /// <typeparam name="T">The Type of the object to be returned.</typeparam>
        /// <returns>Http Response with expected type.</returns>
        public async Task<HttpResponseMessage> MakeRequestWithBody<T> (string fullUrl, T obj) where T : class {
            var jsonFromObj = JsonConvert.SerializeObject (obj);
            var requestMessage = CreateRequestMessage (HttpMethod.Post, fullUrl);
            requestMessage.Content = new StringContent(
                jsonFromObj, 
                Encoding.UTF8, 
                "application/json");
            
            using var client = new HttpClient ();
            var response = await client.SendAsync (
                requestMessage
            );

            return response;
        }

        /// <summary>
        /// Helper method to reduce duplicate logic when creating a marvel request.
        /// </summary>
        /// <param name="method">The marvel request method</param>
        /// <param name="url">The Url to request to.</param>
        /// <returns></returns>
        private HttpRequestMessage CreateRequestMessage (HttpMethod method, string url) {
            var requestMessage = new HttpRequestMessage (method, url);
            var authorizationHeaderValue = ResolveIdentityToken(_httpContextAccessor.HttpContext);

            requestMessage.Headers.Add ("Accept", "*/*");
            requestMessage.Headers.Add ("Sec-Fetch-Mode", "cors");
            if (!(authorizationHeaderValue is null))
                requestMessage.Headers.Add("Authorization", $"Bearer {authorizationHeaderValue}");

            return requestMessage;
        }

        /// <summary>
        /// Accepts the <see cref="HttpContext"/>, and returns the token from the
        /// <see cref="Authorization"/> <see cref="HttpContext.Request.Headers"/> property.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/> From <see cref="HttpRequest"/></param>
        /// <returns><see cref="string"/> Id_Token.</returns>
        private static string ResolveIdentityToken(HttpContext httpContext)
        {
            var requestToken = httpContext?.Request.Headers["Authorization"]
                .ToString()
                .Split(" ")
                [1];
                
            return requestToken;
        }
    }
}