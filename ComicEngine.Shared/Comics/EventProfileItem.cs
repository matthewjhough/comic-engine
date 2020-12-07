using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Shared.Comics {
    [Table ("EventProfileItems")]
    public class EventProfileItem : ProfileItem {
        public int EventProfileId { get; set; }
    }
}