using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComicEngine.Shared.Comics {
    public abstract class Profile {
        [Key]
        public int Id { get; set; }

        public int Available { get; set; }

        public int Returned { get; set; }

        public string CollectionUri { get; set; }
    }

    public class GenericProfile : Profile {
        public IEnumerable<ProfileItem> Items { get; set; }
    }
}