using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Server.Actions.Marvels;
using ComicEngine.Shared;
using ComicEngine.Shared.Comics;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Marvel {
    [Authorize]
    [ApiController]
    public class MarvelControllerV1 : Controller {
        private readonly ILogger _logger;

        private readonly IGetMarvelAction _getMarvelComic;

        /// <summary>
        /// Constructor for <see cref="MarvelControllerV1" />
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="getMarvelComicAction"></param>
        public MarvelControllerV1 (
            ILogger<MarvelControllerV1> logger,
            IGetMarvelAction getMarvelComicAction) {

            _getMarvelComic = getMarvelComicAction;
            _logger = logger;
        }

        /// <summary>
        /// Returns a marvel comic that matches upc submitted.
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        [HttpGet (EndpointsV1.MarvelComicsUpcEndpoint)]
        public async Task<Comic> GetComicByUpc ([FromQuery] string upc) {
            _logger.LogDebug ("Request received with upc code: {upc}", upc);

            if (upc is null) {
                _logger.LogDebug ("UPC cannot be a null value.", upc);
                throw new ArgumentNullException ();
            }

            Comic comicResponse = await _getMarvelComic.GetByCode (upc);

            _logger.LogDebug ("Returning comic: {marvelResponse}", comicResponse?.Title);

            return comicResponse;
        }

        [HttpGet (EndpointsV1.MarvelComicsSearchEndpoint)]
        public async Task<IEnumerable<Comic>> GetComicByTitleAndIssue ([FromQuery] string title, string issueNumber) {
            _logger.LogDebug ("Request received with parameters: \ntitle: {title}\nissueNumber: {issueNumber}", title, issueNumber);

            var comicResponse = await _getMarvelComic.GetByTitleAndIssueNumber (title, issueNumber) as IEnumerable<Comic>;

            _logger.LogDebug ("Found {number} comics", comicResponse.Count ());

            return comicResponse;
        }
    }
}