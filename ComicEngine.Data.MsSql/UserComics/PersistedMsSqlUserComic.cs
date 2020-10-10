using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComicEngine.Common.Comic;

namespace ComicEngine.Data.MsSql.UserComics
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