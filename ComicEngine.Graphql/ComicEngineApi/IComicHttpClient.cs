using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Graphql.ComicEngineApi {
    /// <summary>
    /// The ComicHttpClient is intended to be a helper class to handle a lot of the repeat logic
    /// when making an Http request to the comic api endpoint.
    /// </summary>
    public interface IComicHttpClient {
        Task<T> RequestComicFromApi<T> (string endpoint, string parameters = "");

        Task<T> PostComicToApi<T> (string endpoint, string parameters);

        string GetQueryString (object obj);
    }
}