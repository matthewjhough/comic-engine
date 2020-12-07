using System.Threading.Tasks;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.Commands.UserComics {
    public interface ICreateUserComicCommand {
        Task<UserComic> CreateUserComicAsync (Comic comic, string subject);
    }
}