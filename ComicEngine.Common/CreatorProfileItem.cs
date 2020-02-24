using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("CreatorProfileItems")]
    public class CreatorProfileItem : ProfileItem {
        public int CreatorProfileId { get; set; }
    }
}