using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;
using ComicEngine.State;

namespace ComicEngine.Api.UserComics.CreateUserComic.States
{
    public class CreateUserComicState : BaseState
    {
        public string InputSubject { get; set; }
        public Comic InputComic { get; set; }
        public UserComic ResultUserComic { get; set; }
    }
}