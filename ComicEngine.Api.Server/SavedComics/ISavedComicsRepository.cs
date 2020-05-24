using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Data;

namespace ComicEngine.Api.Server.SavedComics {
    public interface ISavedComicsRepository : IDataRepository {
        Task CreateSavedComic (Comic comic);

        /// <summary>
        /// Gets all stored comics by current user's id.
        /// </summary>
        /// <returns>A list of user's saved <see cref="Comic"/>.</returns>
        Task<IEnumerable<Comic>> GetSavedComics ();
    }
}