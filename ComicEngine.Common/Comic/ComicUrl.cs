using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Common.Comic {
    public class ComicUrl {
        [ForeignKey ("Comic")]
        [GraphQLIgnore]
        public int ComicUrlId { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}