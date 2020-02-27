using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;

namespace ComicEngine.Client.ComicEngineApi {
    public interface IComicEngineApiService {
        /// <summary>
        /// Method to initiate Http Request. This method handles a lot of repeat logic.
        /// </summary>
        /// <returns>Basic comic data object from Api.</returns>
        Task<Comic> RequestComicByParameters (string parameters, string endpoint = "");

        /// <summary>
        /// Method to initiate an http request that will return more than one result.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="endpoint"></param>
        /// <remarks>This ideally would be used to search by a few params to narrow down a comic before making a selection</remarks>
        /// <returns>A list of a few comic results</returns>
        Task<IList<Comic>> RequestComicsByParameters (
            string parameters,
            string endpoint = ""
        );

        Task<IEnumerable<Comic>> RequestAllSavedComics ();
    }
}