using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace ComicEngine.Shared.Comics {
    public abstract class ProfileItem {
        [Key]
        public int Id { get; set; }

        [GraphQLIgnore]
        public int ComicStorageId { get; set; }

        public string ResourceUri { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }

    public class GenericProfileItem : ProfileItem {

    }
}