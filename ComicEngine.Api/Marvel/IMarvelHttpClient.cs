using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.Marvel {
    public interface IMarvelHttpClient {
        /// <summary>
        /// Returns a marvel response object containing marvel comic data.
        /// </summary>
        /// <returns>Large marvel-format response object</returns>
        Task<MarvelResponse> GetAllComics ();

        /// <summary>
        /// Accepts barcode number, and returns basic comic object response.
        /// </summary>
        /// <returns></returns>
        Task<Comic> GetByCode (string ean);

        /// <summary>
        /// Takes in comic title, and issue number and fetches marvel's /comic endpoint.
        /// </summary>
        /// <param name="title">Title of comic book ex: Thor</param>
        /// <param name="issueNumber">Marvel's comic book number (could be cumulative or current series number)</param>
        /// <returns></returns>
        Task<IList<Comic>> GetByTitleAndIssueNumber (string title, string issueNumber);
    }
}