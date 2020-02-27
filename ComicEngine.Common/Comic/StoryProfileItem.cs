using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("StoryProfileItems")]
    public class StoryProfileItem : ProfileItem {
        public int StoryProfileId { get; set; }
    }
}