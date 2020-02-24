using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("EventProfileItems")]
    public class EventProfileItem : ProfileItem {
        public int EventProfileId { get; set; }
    }
}