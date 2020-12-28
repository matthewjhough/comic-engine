using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Shared.Comics {
    [Table ("CreatorProfiles")]
    public class CreatorProfile : Profile {
        public IEnumerable<CreatorProfileItem> Items { get; set; }
    }
}