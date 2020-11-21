using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comics {
    [Table ("CreatorProfiles")]
    public class CreatorProfile : Profile {
        public IEnumerable<CreatorProfileItem> Items { get; set; }
    }
}