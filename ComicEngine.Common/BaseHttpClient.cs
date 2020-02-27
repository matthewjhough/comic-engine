using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ComicEngine.Common {
    public abstract class BaseHttpClient {

        /// <summary>
        /// Sends an HTTP request to get comic(s)
        /// </summary>
        /// <returns></returns>
        public async Task<T> MakeRequest<T> (HttpMethod method, string url) {
            var httpClient = new HttpClient ();

            HttpRequestMessage requestMessage = CreateRequestMessage (method, url);
            var response = await httpClient.SendAsync (requestMessage);

            try {
                if (response.IsSuccessStatusCode) {
                    var responseStream = await response.Content.ReadAsStreamAsync ();
                    var serializer = new JsonSerializer ();

                    using (StreamReader reader = new StreamReader (responseStream))
                    using (var jsonTextReader = new JsonTextReader (reader)) {
                        return serializer.Deserialize<T> (jsonTextReader);
                    }
                } else {
                    return default (T);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Helper method to reduce duplicate logic when creating a marvel request.
        /// </summary>
        /// <param name="route">The marvel api route intended to send a request</param>
        /// <param name="query">The search/query parameters to filter by (query string param format)</param>
        /// <returns></returns>
        private HttpRequestMessage CreateRequestMessage (HttpMethod method, string url) {
            var requestMessage = new HttpRequestMessage (method, url);

            requestMessage.Headers.Add ("Accept", "*/*");
            requestMessage.Headers.Add ("Sec-Fetch-Mode", "cors");

            return requestMessage;
        }
    }
}