using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace ComicEngine.Shared.Comics {
    [Table ("CharacterProfileItems")]
    public class CharacterProfileItem : ProfileItem {
        [GraphQLIgnore]
        public int CharacterProfileId { get; set; }
    }
}