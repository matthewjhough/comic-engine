using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comics;
using ComicEngine.Common.UserComics;

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

        Task<IEnumerable<UserComic>> RequestAllUserComics (string userId);

        Task<UserComic> SaveComicToApi (Comic comic, string userId);
    }
}