using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("ComicUrls")]
    public class ComicUrl {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}