using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common.Comic {
    public abstract class Profile {
        [Key]
        public int Id { get; set; }

        public int Available { get; set; }

        public int Returned { get; set; }

        public string CollectionUri { get; set; }
    }
}