using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    public class ComicUrl {
        [ForeignKey ("Comic")]
        public int ComicUrlId { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}