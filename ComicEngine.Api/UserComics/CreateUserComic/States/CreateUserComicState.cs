using Automatonymous;
using ComicEngine.Common.Comics;
using ComicEngine.Common.UserComics;

namespace ComicEngine.Api.UserComics.CreateUserComic.States
{
    public class CreateUserComicState
    {
        public State CurrentState { get; set; }
        public string InputSubject { get; set; }
        public Comic InputComic { get; set; }
        public UserComic ResultUserComic { get; set; }
    }
}