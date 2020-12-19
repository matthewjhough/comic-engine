using ComicEngine.Shared.Comics;
using ComicEngine.Shared.StorageContainers;
using ComicEngine.Shared.UserComics;
using ComicEngine.State;

namespace ComicEngine.Api.Server.UserComics.CreateUserComic.States
{
    public class CreateUserComicState : BaseState
    {
        public string InputSubject { get; set; }
        public Comic InputComic { get; set; }
        public StorageContainer InputStorageContainer { get; set; }
        public UserComic ResultUserComic { get; set; }
    }
}