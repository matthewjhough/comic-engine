using ComicEngine.Common.Comics;
using ComicEngine.Common.StorageContainers;

namespace ComicEngine.Common.UserComics
{
    public class UserComic
    {
        public string UserId { get; set; }

        public Comic Comic { get; set; }
        
        public StorageContainer StorageContainer { get; set; }
    }
}