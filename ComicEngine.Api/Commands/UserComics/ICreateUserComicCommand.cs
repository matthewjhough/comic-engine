using System.Threading.Tasks;
using ComicEngine.Common.Comics;
using ComicEngine.Common.UserComics;

namespace ComicEngine.Api.Commands.UserComics {
    public interface ICreateUserComicCommand {
        Task<UserComic> CreateUserComicAsync (Comic comic, string subject);
    }
}