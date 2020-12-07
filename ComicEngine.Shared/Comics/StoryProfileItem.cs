using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Shared.Comics {
    [Table ("StoryProfileItems")]
    public class StoryProfileItem : ProfileItem {
        public int StoryProfileId { get; set; }
    }
}