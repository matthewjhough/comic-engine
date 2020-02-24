using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("StoryProfiles")]
    public class StoryProfile {
        [ForeignKey ("StoryProfileId")]
        public IEnumerable<StoryProfileItem> Items { get; set; }
    }
}