using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ComicEngine.Common {
    public abstract class BaseHttpClient {

        /// <summary>
        /// Sends an HTTP request to get comic(s)
        /// </summary>
        /// <returns></returns>
        public async Task<T> MakeRequest<T> (HttpMethod method, string url, string queryParameters = null) {
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

        public async Task<HttpResponseMessage> MakeRequestWithBody<T> (string fullUrl, T obj) where T : class {
            string jsonFromObj = JsonConvert.SerializeObject (obj);
            using (var client = new HttpClient ()) {
                var response = await client.PostAsync (
                    fullUrl,
                    new StringContent (jsonFromObj, Encoding.UTF8, "application/json"));

                return response;
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