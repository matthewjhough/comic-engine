using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.Server.Actions.UserComics {
    public interface IGetUserComicAction {
        /// <summary>
        /// Gets all saved <see cref="Comic">s.!--
        /// 
        /// This should grab all comics from the user's saved comics per ID of user sent in request.
        /// </summary>
        /// <returns>A list of the user's saved <see cref="Comic"/>s.</returns>
        Task<IEnumerable<UserComic>> GetUserComics (string subject);
    }
}