using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("CharacterProfileItems")]
    public class CharacterProfileItem : ProfileItem {
        public int CharacterProfileId { get; set; }
    }
}