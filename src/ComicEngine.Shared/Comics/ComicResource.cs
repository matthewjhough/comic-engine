using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Shared.Comics {
    public class ComicResource {
        [ForeignKey ("Comic")]
        [GraphQLIgnore]
        public int ComicResourceId { get; set; }
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }
}