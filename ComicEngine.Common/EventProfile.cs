using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("EventProfiles")]
    public class EventProfile {
        [ForeignKey ("EventProfileId")]
        public IEnumerable<EventProfileItem> Items { get; set; }
    }
}