using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicEngine.Common {
    [Table ("ProfileItems")]
    public class ProfileItem {
        [Key]
        public int Id { get; set; }

        public string ResourceUri { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}