using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Identity.Client.Impl
{
    public class HttpRequestClient<T>
    {
        private static readonly ILogger Logger = new LoggerFactory().CreateLogger(nameof(HttpRequestClient<T>));
        internal IHttpContextAccessor HttpContextAccessor { get; set; }
        internal Dictionary<string, string> RequestHeaders { get; set; }
        internal HttpMethod Method { get; set; }
        internal string RequestToken { get; set; }
        internal T RequestBody { get; set; }
        internal string RelativeUrl { get; set; }
        internal string AbsoluteUrl { get; set; }

        private static readonly string AccessToken = "access_token";
        internal TokenClientSettings TokenClientSettings { get; set; }

        /// <summary>
        /// Assembles the properties defined into an <see cref="HttpClient"/>,
        /// then makes a request, and parses the response.
        /// </summary>
        /// <returns><see cref="T"/> <see cref="HttpResponse"/></returns>
        public async Task<T> Send()
        {
            var requestMessage = await CreateRequestMessage();
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
        private async Task<HttpRequestMessage> CreateRequestMessage () {
            var requestMessage = new HttpRequestMessage(Method, AbsoluteUrl);
            requestMessage = await AddHeadersToRequestMessage(requestMessage);
            requestMessage = AddRequestBody(requestMessage);
            
            return requestMessage;
        }

        /// <summary>
        /// Applies <see cref="RequestHeaders"/> To <see cref="HttpRequestMessage"/>.
        /// Will add Request token if one not defined.
        /// </summary>
        /// <remarks>This would be whatever user defined headers should appear, in addition to the access token.</remarks>
        /// <param name="requestMessage"><see cref="HttpRequestMessage"/></param>
        /// <returns><see cref="HttpRequestMessage"/></returns>
        private async Task<HttpRequestMessage> AddHeadersToRequestMessage(
            HttpRequestMessage requestMessage)
        {
            // TODO: Set these as defaults, and if provided in RequestHeaders, overwrite instead of add.
            requestMessage.Headers.Add ("Accept", "*/*");
            requestMessage.Headers.Add ("Sec-Fetch-Mode", "cors");

            Logger.LogDebug("Adding request header overrides to request message...");
            if (!(RequestHeaders is null))
            {
                foreach ((var key, var value) in RequestHeaders)
                {
                    requestMessage.Headers.Add(key, value);
                    Logger.LogDebug("added request header {key}, {value} to request message.", key, value);
                }
            }

            if (HttpContextAccessor?.HttpContext is null)
            {
                Logger.LogDebug("HttpContextAccessor was unable to find an http context before getting access token.");
                throw new Exception("No HttpContext found when trying to make request.");
            }

            if (TokenClientSettings is null)
            {
                return requestMessage;
            }

            Logger.LogDebug("getting access token for request...");
            
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(TokenClientSettings.Authority);
            var token = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = TokenClientSettings.ClientId,
                ClientSecret = TokenClientSettings.Secret,
                Scope = TokenClientSettings.Scope,
                GrantType = "client_credentials"
            });
            requestMessage.Headers.Add("Authorization", $"Bearer {token.AccessToken}");
            Logger.LogDebug("access token added to request: {token}", token.AccessToken);

            return requestMessage;
        }
    }
}