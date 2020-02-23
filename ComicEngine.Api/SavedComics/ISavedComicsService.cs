using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.SavedComics {
    public interface ISavedComicsService {
        Task<Comic> AddComicAsync (Comic comic);
    }
}