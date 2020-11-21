using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comics;
using ComicEngine.Data;

namespace ComicEngine.Api.UserComics {
    public interface IUserComicsRepository : IDataRepository {
        Task<Comic> CreateUserComic (Comic comic, string subject);

        /// <summary>
        /// Gets all stored comics by current user's id.
        /// </summary>
        /// <returns>A list of user's saved <see cref="Comic"/>.</returns>
        Task<IEnumerable<Comic>> GetUserComics (string subject);
    }
}