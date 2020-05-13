using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComicEngine.Common.Comic;

namespace ComicEngine.Data.MsSql.Comics {
    [Table ("PersistedComics")]
    public class PersistedComic : PersistedResource {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual Comic Comic { get; set; }
    }
}