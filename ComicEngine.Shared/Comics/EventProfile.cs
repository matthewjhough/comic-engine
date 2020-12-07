using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Shared.Comics {
    [Table ("EventProfiles")]
    public class EventProfile : Profile {
        public IEnumerable<EventProfileItem> Items { get; set; }
    }
}