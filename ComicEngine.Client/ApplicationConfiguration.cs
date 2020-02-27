using ComicEngine.Client.ComicEngineApi;
using ComicEngine.Client.ComicEngineApi.HttpClient;

namespace ComicEngine.Client {
    public class ApplicationConfiguration {
        // configuration for API Http Client.
        public ComicHttpClientConfig ComicHttpClientConfig { get; set; }
    }
}