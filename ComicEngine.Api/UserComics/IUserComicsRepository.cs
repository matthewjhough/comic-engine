using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Data;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.UserComics {
    public interface IUserComicsRepository : IDataRepository {
        Task<UserComic> CreateUserComic (UserComic comic, string subject);

        Task<bool> DeleteUserComic(string userComicId, string subject);

        /// <summary>
        /// Gets all stored comics by current user's id.
        /// </summary>
        /// <returns>A list of user's saved <see cref="Comic"/>.</returns>
        Task<IEnumerable<UserComic>> GetUserComics (string subject);
    }
}