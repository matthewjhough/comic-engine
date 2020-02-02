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
        async public Task<BasicComic> RequestComicByParameters (
            string parameters,
            string endpoint = ""
        ) {
            var serializedComicString = await _apiClient.RequestSerializedComics (parameters, endpoint);
            BasicComic deserializedComic = JsonConvert.DeserializeObject<BasicComic> (serializedComicString);

            return deserializedComic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        async public Task<IList<BasicComic>> RequestComicsByParameters (
            string parameters,
            string endpoint = ""
        ) {
            var serializedComicString = await _apiClient.RequestSerializedComics (parameters, endpoint);
            List<BasicComic> deserializedComicList = JsonConvert.DeserializeObject<List<BasicComic>> (serializedComicString);

            return deserializedComicList;
        }

    }
}