using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.SavedComics {
    public interface ISavedComicsRepository {
        Task CreateSavedComic (Comic comic);

        /// <summary>
        /// Gets all stored comics by current user's id.
        /// </summary>
        /// <returns>A list of user's saved <see cref="Comic"/>.</returns>
        Task<IEnumerable<Comic>> GetSavedComics ();

        /// <summary>
        /// Gets comic by stored id of comic.
        /// </summary>
        /// <param name="storedId"></param>
        /// <returns>a stored <see cref="Comic"/>.</returns>
        // Task<Comic> GetSavedComicByStoredId (string storedId);
    }
}