using ComicEngine.Shared.Comics;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Shared.UserComics
{
    public class UserComic
    {
        public string UserId { get; set; }
        
        public string Id { get; set; }

        public Comic Comic { get; set; }
        
        public StorageContainer StorageContainer { get; set; }
    }
}