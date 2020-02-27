using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("ComicImageResources")]
    public class ComicImageResource {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }
    }
}