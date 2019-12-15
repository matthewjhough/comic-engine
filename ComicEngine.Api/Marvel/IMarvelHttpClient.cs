using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.Marvel {
    public interface IMarvelHttpClient {
        /// <summary>
        /// Returns a marvel response object containing marvel comic data.
        /// </summary>
        /// <returns></returns>
        Task<MarvelResponse> GetAllComics ();

        /// <summary>
        /// Accepts barcode number, and returns basic comic object response.
        /// </summary>
        /// <returns></returns>
        Task<BasicComic> GetByCode (string ean);
    }
}