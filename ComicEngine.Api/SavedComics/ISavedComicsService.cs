using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.SavedComics {
    public interface ISavedComicsService {
        Task<Comic> CreateSavedComicAsync (Comic comic);

        /// <summary>
        /// Gets all saved <see cref="Comic">s.!--
        /// 
        /// This should grab all comics from the user's saved comics per ID of user sent in request.
        /// </summary>
        /// <returns>A list of the user's saved <see cref="Comic"/>s.</returns>
        Task<IEnumerable<Comic>> GetSavedComics ();
    }
}