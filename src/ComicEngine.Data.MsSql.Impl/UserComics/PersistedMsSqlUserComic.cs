using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComicEngine.Shared.Comics;

namespace ComicEngine.Data.MsSql.Impl.UserComics
{
    [Table ("PersistedComics")]
    public sealed class PersistedMsSqlUserComic : PersistedResource
    {
        [Key]
        public string Id { get; set; }
        
        public string UserId { get; set; }

        public Comic Comic { get; set; }
    }
}