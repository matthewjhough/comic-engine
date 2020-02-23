using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.SavedComics {
    public interface ISavedComicsRepository {
        Task CreateSavedComic (Comic comic);
    }
}