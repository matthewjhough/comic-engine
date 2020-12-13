using ComicEngine.Api.Client;

namespace ComicEngine.Graphql {
    public class ApplicationConfiguration {
        // configuration for API Http Client.
        public ComicEngineApiRepositoryConfiguration ComicEngineApiRepositoryConfiguration { get; set; }
    }
}