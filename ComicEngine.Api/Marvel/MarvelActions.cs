using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Actions.Marvels;
using ComicEngine.Shared.Comics;
using ComicEngine.Shared.Marvels;

namespace ComicEngine.Api.Marvel {
    public class MarvelActions : IGetMarvelAction {
        private readonly MarvelHttpClient _marvelClient;
        public MarvelActions (MarvelHttpClient marvelClient) {
            _marvelClient = marvelClient;
        }

        /// <summary>
        /// Fetches matching comic based on barcode isbn number.
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        public async Task<Comic> GetByCode (string upc) {
            MarvelResponse comicResponse = await _marvelClient.RequestComic ("/comics", $"upc={upc}");
            MarvelComic comicData = comicResponse
                .Data
                .Results
                .FirstOrDefault ();

            if (comicData is null) {
                return new Comic ();
            }

            Comic comic = MapResponseToComic (comicData, comicResponse.Copyright);

            return comic;
        }

        /// <summary>
        /// Sends a request to Marvel's API, and returns comics found based on title,
        /// and issue number.
        /// </summary>
        /// <param name="title">The title of the <see cref="Comic"/></param>
        /// <param name="issueNumber">The issue number of the <see cref="Comic"/></param>
        /// <returns>An <see cref="IEnumerable{Comic}"/> of comic results.</returns>
        public async Task<IList<Comic>> GetByTitleAndIssueNumber (string title, string issueNumber) {
            // TODO: create & move this to a 'marvel client' project, and make a repository.
            MarvelResponse comicResponse = await _marvelClient.RequestComic (
                "/comics",
                $"title={title}&issueNumber={issueNumber}"
            );

            IEnumerable<MarvelComic> comicData = comicResponse
                .Data
                .Results.AsEnumerable ();

            if (comicData is null) {
                return new List<Comic> ();;
            }

            var comics = comicData
                .Select (marvelComic =>
                    MapResponseToComic (marvelComic, comicResponse.Copyright))
                .ToList ();

            return comics;
        }

        /// <summary>
        /// Helper method to take care of repeat mapping logic.
        /// </summary>
        /// <param name="marvelComic"></param>
        /// <param name="copyright"></param>
        /// <returns><see cref="Comic"/></returns>
        private static Comic MapResponseToComic (MarvelComic marvelComic, string copyright)
        {
            return new Comic {
                Id = marvelComic.Id,
                Copyright = copyright,
                IssueNumber = marvelComic.IssueNumber,
                Title = marvelComic.Title,
                Upc = marvelComic.Upc,
                Description = marvelComic.Description,
                Characters = marvelComic.Characters,
                Creators = marvelComic.Creators,
                Series = marvelComic.ComicSeries,
                PublishDates = marvelComic.Dates.ToList (),
                PageCount = marvelComic.PageCount,
                ResourceUri = marvelComic.ResourceUri,
                Thumbnail = $"{marvelComic.Thumbnail.Path}.{marvelComic.Thumbnail.Extension}",
                RelevantLinks = marvelComic.Urls
            };
        }
    }
}