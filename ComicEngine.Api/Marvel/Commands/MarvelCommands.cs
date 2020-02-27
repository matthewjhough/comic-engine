using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using ComicEngine.Common.Marvel;

namespace ComicEngine.Api.Marvel.Commands {
    public class MarvelCommands : IGetMarvelCommand {

        private MarvelHttpClientV1 _marvelClient;

        public MarvelCommands (MarvelHttpClientV1 marvelClient) {
            _marvelClient = marvelClient;
        }

        /// <summary>
        /// Fetches matching comic based on barcode isbn number.
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public async Task<Comic> GetByCode (string upc) {
            HttpRequestMessage request = _marvelClient.CreateRequestMessage ("/comics", $"upc={upc}");

            MarvelResponse comicResponse = await _marvelClient.RequestComic (request, "marvelByCode");
            MarvelComic comicData = comicResponse
                .Data
                .Results
                .FirstOrDefault ();

            if (comicData is null) {
                return new Comic ();
            }

            Comic comic = _marvelClient.MapResponseToComic (comicData, comicResponse.Copyright);

            return comic;
        }

        async public Task<IList<Comic>> GetByTitleAndIssueNumber (string title, string issueNumber) {
            var request = _marvelClient.CreateRequestMessage (
                "/comics", $"title={title}&issueNumber={issueNumber}"
            );

            MarvelResponse comicResponse = await _marvelClient.RequestComic (request, "marvelByTitleIssueNumber");
            IEnumerable<MarvelComic> comicData = comicResponse
                .Data
                .Results.AsEnumerable ();

            if (comicData is null) {
                return new List<Comic> ();;
            }

            var comics = comicData
                .Select (marvelComic =>
                    _marvelClient.MapResponseToComic (marvelComic, comicResponse.Copyright))
                .ToList ();

            return comics;
        }
    }
}