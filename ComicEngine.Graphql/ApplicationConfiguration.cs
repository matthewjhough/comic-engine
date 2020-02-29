using ComicEngine.Graphql.ComicEngineApi;
using ComicEngine.Graphql.HttpClients;

namespace ComicEngine.Graphql {
    public class ApplicationConfiguration {
        // configuration for API Http Client.
        public ComicHttpClientConfig ComicHttpClientConfig { get; set; }
    }
}