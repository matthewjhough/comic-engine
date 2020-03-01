using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Common.Marvel;

namespace ComicEngine.Api.Marvel.Commands {
    public class MarvelCommands : IGetMarvelCommand {

        private MarvelHttpClient _marvelClient;

        public MarvelCommands (MarvelHttpClient marvelClient) {
            _marvelClient = marvelClient;
        }

        /// <summary>
        /// Fetches matching comic based on barcode isbn number.
        /// </summary>
        /// <param name="isbn"></param>
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

        public async Task<IList<Comic>> GetByTitleAndIssueNumber (string title, string issueNumber) {
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
        /// <returns>Comic POCO</returns>
        private Comic MapResponseToComic (MarvelComic marvelComic, string copyright) {
            try {
                return new Comic () {
                    Id = marvelComic.Id,
                        Copyright = copyright,
                        IssueNumber = marvelComic.IssueNumber,
                        Title = marvelComic.Title,
                        Upc = marvelComic.Upc,
                        Description = marvelComic.Description,
                        Characters = marvelComic.Characters as CharacterProfile,
                        Creators = marvelComic.Creators as CreatorProfile,
                        Series = marvelComic.ComicSeries,
                        // PublishDates = marvelComic.Dates.ToList (),
                        PageCount = marvelComic.PageCount,
                        ResourceUri = marvelComic.ResourceUri,
                        Thumbnail = $"{marvelComic.Thumbnail.Path}.{marvelComic.Thumbnail.Extension}",
                        // RelevantLinks = marvelComic.Urls
                };
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}