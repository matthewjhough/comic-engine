using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("CreatorProfiles")]
    public class CreatorProfile : Profile {
        public IEnumerable<CreatorProfileItem> Items { get; set; }
    }
}