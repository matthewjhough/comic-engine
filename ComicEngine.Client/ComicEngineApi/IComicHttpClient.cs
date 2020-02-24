using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Client.ComicEngineApi {
    /// <summary>
    /// The ComicHttpClient is intended to be a helper class to handle a lot of the repeat logic
    /// when making an Http request to the comic api endpoint.
    /// </summary>
    public interface IComicHttpClient {

        /// <summary>
        /// Send request to Comic Engine Api with parameters and optional endpoint.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="endpoint"></param>
        /// <returns>Serialized json string with results</returns>
        Task<string> RequestSerializedComics (string parameters, string endpoint = "");

        Task<string> RequestComicFromApi (string endpoint, string parameters = "");
    }
}