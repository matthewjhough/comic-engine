using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("EventProfileItems")]
    public class EventProfileItem : ProfileItem {
        public int EventProfileId { get; set; }
    }
}