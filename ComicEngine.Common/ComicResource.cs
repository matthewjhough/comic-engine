using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    public class ComicResource {
        [ForeignKey ("Comic")]
        public int ComicResourceId { get; set; }
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }
}