using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComicEngine.Data.UserComics;

namespace ComicEngine.Data.MsSql.UserComics
{
    [Table ("PersistedComics")]
    public class PersistedMsSqlUserComic : PersistedUserComic
    {
        [Key]
        public override int Id { get; set; }
    }
}