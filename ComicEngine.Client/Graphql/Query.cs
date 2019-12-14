using ComicEngine.Common;

namespace ComicEngine.Client.Graphql {
    public class Query {
        public BasicComic BasicComic (string isbn) => new BasicComic {
            Isbn = isbn
        };
    }
}