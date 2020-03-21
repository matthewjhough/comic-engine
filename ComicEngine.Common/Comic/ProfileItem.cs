using System.ComponentModel.DataAnnotations;

namespace ComicEngine.Common.Comic {
    public abstract class ProfileItem {
        [Key]
        public int Id { get; set; }

        public int ComicStorageId { get; set; }

        public string ResourceUri { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }

    public class GenericProfileItem : ProfileItem {

    }
}