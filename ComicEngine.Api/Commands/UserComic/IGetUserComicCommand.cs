using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.Commands.UserComic {
    public interface IGetUserComicCommand {
        /// <summary>
        /// Gets all saved <see cref="Comic">s.!--
        /// 
        /// This should grab all comics from the user's saved comics per ID of user sent in request.
        /// </summary>
        /// <returns>A list of the user's saved <see cref="Comic"/>s.</returns>
        Task<IEnumerable<Comic>> GetUserComics (string subject);
    }
}