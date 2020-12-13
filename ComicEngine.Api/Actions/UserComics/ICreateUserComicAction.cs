using System.Threading.Tasks;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.Actions.UserComics {
    public interface ICreateUserComicAction {
        Task<UserComic> CreateUserComicAsync (Comic comic, string subject);
    }
}