using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("CharacterProfiles")]
    public class CharacterProfile {
        [ForeignKey ("CharacterProfileId")]
        public IEnumerable<CharacterProfileItem> Items { get; set; }
    }
}