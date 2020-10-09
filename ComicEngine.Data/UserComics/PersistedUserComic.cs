using ComicEngine.Common.Comic;

namespace ComicEngine.Data.UserComics {
    
    public class PersistedUserComic : PersistedResource {
        public virtual int Id { get; set; }

        public string UserId { get; set; }

        public virtual Comic Comic { get; set; }
    }
}