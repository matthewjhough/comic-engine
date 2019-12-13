using System.Threading.Tasks;

namespace ComicEngine.Api.Marvel {
    public interface IMarvelHttpClient {
        /// <summary>
        /// Returns a marvel response object containing marvel comic data.
        /// </summary>
        /// <returns></returns>
        Task<MarvelResponse> GetAllComics ();
    }
}