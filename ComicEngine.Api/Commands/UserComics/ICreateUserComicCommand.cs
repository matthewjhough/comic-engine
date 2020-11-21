using System.Threading.Tasks;
using ComicEngine.Common.Comics;

namespace ComicEngine.Api.Commands.UserComics {
    public interface ICreateUserComicCommand {
        Task<Comic> CreateUserComicAsync (Comic comic, string subject);
    }
}