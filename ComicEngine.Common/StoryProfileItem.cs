using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("StoryProfileItems")]
    public class StoryProfileItem : ProfileItem {
        public int StoryProfileId { get; set; }
    }
}