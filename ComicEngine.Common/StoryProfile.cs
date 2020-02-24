using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("StoryProfiles")]
    public class StoryProfile : Profile {
        public IEnumerable<StoryProfileItem> Items { get; set; }
    }
}