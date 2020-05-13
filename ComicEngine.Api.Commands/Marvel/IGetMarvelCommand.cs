using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.Commands.Marvel {
    public interface IGetMarvelCommand {
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