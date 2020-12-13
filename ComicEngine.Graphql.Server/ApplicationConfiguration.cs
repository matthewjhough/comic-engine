using ComicEngine.Api.Client;

namespace ComicEngine.Graphql.Server {
    public class ApplicationConfiguration {
        // configuration for API Http Client.
        public ComicEngineApiConfiguration ComicEngineApiConfiguration { get; set; }
    }
}