using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.Commands.SavedComics {
    public interface ICreateSavedComicCommand {
        Task<Comic> CreateSavedComicAsync (Comic comic);
    }
}