using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.Client {
    public interface IComicHttpRepository {
        /// <summary>
        /// Method to initiate Http Request. This method handles a lot of repeat logic.
        /// </summary>
        /// <returns>Basic comic data object from Api.</returns>
        Task<Comic> RequestMarvelComicByUpc (string upc);

        /// <summary>
        /// Method to initiate an http request that will return more than one result.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="issueNumber"></param>
        /// <remarks>This ideally would be used to search by a few params to narrow down a comic before making a selection</remarks>
        /// <returns>A list of a few comic results</returns>
        Task<IEnumerable<Comic>> RequestMarvelComicsByParameters (
            string title, string issueNumber
        );

        /// <summary>
        /// Retrieves all comics associated with a user.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserComic>> RequestAllUserComics (string userId);

        /// <summary>
        /// Saves a <see cref="Comic"/> to the users saved comics.
        /// </summary>
        /// <param name="comic">The <see cref="Comic"/> to be saved to the user's collection</param>
        /// <param name="userId">The id or subject of the user making the request.</param>
        /// <returns><see cref="Comic"/></returns>
        Task<UserComic> SaveComicToApi (Comic comic, string userId);

        /// <summary>
        /// Deletes a <see cref="Comic"/> to the users saved comics.
        /// </summary>
        /// <param name="userComicId">The <see cref="Comic"/> to be saved to the user's collection</param>
        /// <param name="userId"></param>
        /// <returns>boolean relaying whether or not the user comic was deleted</returns>
        Task<bool> DeleteUserComic(string userComicId, string userId);
    }
}