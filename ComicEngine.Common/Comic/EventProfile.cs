using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    [Table ("EventProfiles")]
    public class EventProfile : Profile {
        public IEnumerable<EventProfileItem> Items { get; set; }
    }
}