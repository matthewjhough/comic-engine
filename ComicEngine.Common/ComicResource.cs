using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("ComicResources")]
    public class ComicResource {
        [Key]
        public int Id { get; set; }
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }
}