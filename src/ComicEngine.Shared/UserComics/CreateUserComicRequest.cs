using ComicEngine.Shared.Comics;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Shared.UserComics
{
    public class CreateUserComicRequest
    {
        public StorageContainer StorageContainer { get; set; }
        public Comic Comic { get; set; }
    }
}