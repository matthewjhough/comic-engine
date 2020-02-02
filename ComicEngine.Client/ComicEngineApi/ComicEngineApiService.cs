using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Client.ComicEngineApi;
using ComicEngine.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicEngine.Client.ComicEngineApi {
    public class ComicEngineApiService : IComicEngineApiService {

        private ILogger _logger;
        private IComicHttpClient _apiClient;

        public ComicEngineApiService (ILogger<ComicEngineApiService> logger, IComicHttpClient apiClient) {
            _logger = logger;
            _apiClient = apiClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        async public Task<Comic> RequestComicByParameters (
            string parameters,
            string endpoint = ""
        ) {
            var serializedComicString = await _apiClient.RequestSerializedComics (parameters, endpoint);
            Comic deserializedComic = JsonConvert.DeserializeObject<Comic> (serializedComicString);

            return deserializedComic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        async public Task<IList<Comic>> RequestComicsByParameters (
            string parameters,
            string endpoint = ""
        ) {
            var serializedComicString = await _apiClient.RequestSerializedComics (parameters, endpoint);
            List<Comic> deserializedComicList = JsonConvert.DeserializeObject<List<Comic>> (serializedComicString);

            return deserializedComicList;
        }

    }
}