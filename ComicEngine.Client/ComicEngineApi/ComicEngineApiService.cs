using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Client.ComicEngineApi;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
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

        public async Task<IEnumerable<Comic>> RequestAllSavedComics () {
            string endpoint = "v1/saved/comics";
            string serializedComicString = await _apiClient.RequestComicFromApi (endpoint);
            IEnumerable<Comic> deserializedComic = JsonConvert.DeserializeObject<IEnumerable<Comic>> (serializedComicString);

            return deserializedComic;
        }

        async public Task<Comic> RequestComicByParameters (
            string parameters,
            string endpoint = ""
        ) {
            var serializedComicString = await _apiClient.RequestSerializedComics (parameters, endpoint);
            Comic deserializedComic = JsonConvert.DeserializeObject<Comic> (serializedComicString);

            return deserializedComic;
        }

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