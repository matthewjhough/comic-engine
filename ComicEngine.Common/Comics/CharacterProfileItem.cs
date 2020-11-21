using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Common.Comics {
    [Table ("CharacterProfileItems")]
    public class CharacterProfileItem : ProfileItem {
        [GraphQLIgnore]
        public int CharacterProfileId { get; set; }
    }
}