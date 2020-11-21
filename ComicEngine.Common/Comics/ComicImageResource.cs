using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Common.Comics {
    [Table ("ComicImageResources")]
    public class ComicImageResource {
        [Key]
        [GraphQLIgnore]
        public int Id { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }
    }
}