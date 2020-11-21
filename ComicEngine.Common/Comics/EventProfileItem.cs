using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comics {
    [Table ("EventProfileItems")]
    public class EventProfileItem : ProfileItem {
        public int EventProfileId { get; set; }
    }
}