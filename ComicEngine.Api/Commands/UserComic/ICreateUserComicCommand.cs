using System.Threading.Tasks;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.Commands.UserComic {
    public interface ICreateUserComicCommand {
        Task<Comic> CreateUserComicAsync (Comic comic, string subject);
    }
}