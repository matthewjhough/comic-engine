using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Common.Comic {
    [Table ("CreatorProfileItems")]
    public class CreatorProfileItem : ProfileItem {
        [GraphQLIgnore]
        public int CreatorProfileId { get; set; }
    }
}