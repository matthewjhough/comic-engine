using ComicEngine.Graphql.ComicEngineApi;
using ComicEngine.Graphql.ComicEngineApi.HttpClient;

namespace ComicEngine.Graphql {
    public class ApplicationConfiguration {
        // configuration for API Http Client.
        public ComicHttpClientConfig ComicHttpClientConfig { get; set; }
    }
}