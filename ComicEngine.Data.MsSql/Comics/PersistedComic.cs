using ComicEngine.Common.Comic;

namespace ComicEngine.Data.MsSql.Comics {
    public class PersistedComic : PersistedResource {
        public Comic Comic { get; set; }
    }
}