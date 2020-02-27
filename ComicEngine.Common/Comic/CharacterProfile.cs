using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("CharacterProfiles")]
    public class CharacterProfile : Profile {
        public IEnumerable<CharacterProfileItem> Items { get; set; }
    }
}