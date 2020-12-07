using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Shared.Comics {
    [Table ("CreatorProfileItems")]
    public class CreatorProfileItem : ProfileItem {
        [GraphQLIgnore]
        public int CreatorProfileId { get; set; }
    }
}