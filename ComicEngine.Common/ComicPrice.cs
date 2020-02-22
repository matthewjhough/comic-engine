using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("ComicPrice")]
    public class ComicPrice {
        [Key]
        public int Id { get; set; }

        public float Price { get; set; }

        public string Type { get; set; }
    }
}