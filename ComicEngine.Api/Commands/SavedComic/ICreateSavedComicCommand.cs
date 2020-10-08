using System.Threading.Tasks;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.Commands.SavedComic {
    public interface ICreateSavedComicCommand {
        Task<Comic> CreateSavedComicAsync (Comic comic, string subject);
    }
}