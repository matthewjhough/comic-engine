using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ComicEngine.Identity.Client
{
    public class HttpRequestClient<T>
    {
        internal IHttpContextAccessor HttpContextAccessor { get; set; }
        internal Dictionary<string, string> RequestHeaders { get; set; }
        internal HttpMethod Method { get; set; }
        internal string RequestToken { get; set; }
        internal T RequestBody { get; set; }
        internal string RelativeUrl { get; set; }
        internal string AbsoluteUrl { get; set; }

        /// <summary>
        /// Assembles the properties defined into an <see cref="HttpClient"/>,
        /// then makes a request, and parses the response.
        /// </summary>
        /// <returns><see cref="T"/> <see cref="HttpResponse"/></returns>
        public async Task<T> Send()
        {
            var requestMessage = CreateRequestMessage();
            var response = await MakeRequest(requestMessage);

            return response;
        }

        private async Task<T> MakeRequest (HttpRequestMessage message) {
            var httpClient = new HttpClient ();
            var response = await httpClient.SendAsync (message);

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
        /// Checks if <see cref="RequestBody"/> is set, and if it is, stringifies and adds
        /// to Body, as <see cref="Encoder.UTF8"/> application/json.
        /// </summary>
        /// <param name="requestMessage"><see cref="HttpRequestMessage"/> to mutate.</param>
        /// <returns><see cref="HttpRequestMessage"/></returns>
        private HttpRequestMessage AddRequestBody(HttpRequestMessage requestMessage)
        {
            if (!(RequestBody is null))
            {
                var bodyAsString = JsonConvert.SerializeObject (RequestBody);
                requestMessage.Content = new StringContent(
                    bodyAsString, 
                    Encoding.UTF8, 
                    "application/json");
            }

            return requestMessage;
        }
        
        /// <summary>
        /// Helper method to reduce duplicate logic when creating a marvel request.
        /// </summary>
        /// <returns><see cref="HttpRequestMessage"/> with set properties</returns>
        private HttpRequestMessage CreateRequestMessage () {
            var requestMessage = new HttpRequestMessage(Method, AbsoluteUrl);
            requestMessage = AddHeadersToRequestMessage(requestMessage);
            requestMessage = AddRequestBody(requestMessage);
            
            return requestMessage;
        }

        /// <summary>
        /// Applies <see cref="RequestHeaders"/> To <see cref="HttpRequestMessage"/>.
        /// Will add Request token if one not defined.
        /// </summary>
        /// <param name="requestMessage"><see cref="HttpRequestMessage"/></param>
        /// <returns><see cref="HttpRequestMessage"/></returns>
        private HttpRequestMessage AddHeadersToRequestMessage(
            HttpRequestMessage requestMessage)
        {
            // TODO: Set these as defaults, and if provided in RequestHeaders, overwrite instead of add.
            requestMessage.Headers.Add ("Accept", "*/*");
            requestMessage.Headers.Add ("Sec-Fetch-Mode", "cors");

            if (!(RequestHeaders is null))
            {
                foreach ((var key, var value) in RequestHeaders)
                {
                    requestMessage.Headers.Add(key, value);
                }
            }

            requestMessage = AddAuthorizationToRequestMethod(requestMessage);

            return requestMessage;
        }

        /// <summary>
        /// Checks if <see cref="RequestToken"/> defined, adds if it is, otherwise attempts
        /// to resolve from the HttpContext.
        /// </summary>
        /// <param name="requestMessage">The <see cref="HttpRequestMessage"/> to mutate.</param>
        /// <returns><see cref="HttpRequestMessage"/></returns>
        private HttpRequestMessage AddAuthorizationToRequestMethod(HttpRequestMessage requestMessage)
        {
            if (!(RequestToken is null))
            {
                requestMessage.Headers.Add("Authorization", $"Bearer {RequestToken}");
                return requestMessage;
            }

            if (HttpContextAccessor is null) return requestMessage;
            
            var token = ResolveIdentityToken(HttpContextAccessor.HttpContext);
            if (!(token is null))
            {
                requestMessage.Headers.Add("Authorization", $"Bearer {token}");
            }

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
            try
            {
                var requestToken = httpContext?
                    .Request?
                    .Headers["Authorization"]
                    .ToString()
                    .Split(" ")
                    [1];
                
                return requestToken;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}