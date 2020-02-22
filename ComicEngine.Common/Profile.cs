using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("Profiles")]
    public class Profile {
        [Key]
        public int Id { get; set; }

        public int Available { get; set; }

        public int Returned { get; set; }

        public string CollectionUri { get; set; }

        public List<ProfileItem> Items { get; set; }
    }
}