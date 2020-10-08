using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.Marvel;
using ComicEngine.Common.Comic;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Marvel {
    [Authorize]
    [ApiController]
    public class MarvelControllerV1 : ControllerBase {
        private readonly ILogger _logger;

        private readonly IGetMarvelCommand _getMarvelComic;

        /// <summary>
        /// Constructor for <see cref="MarvelControllerV1" />
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="getMarvelComicCommand"></param>
        public MarvelControllerV1 (
            ILogger<MarvelControllerV1> logger,
            IGetMarvelCommand getMarvelComicCommand) {

            _getMarvelComic = getMarvelComicCommand;
            _logger = logger;
        }

        /// <summary>
        /// Returns a marvel comic that matches upc submitted.
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet ("/v1/marvel/comic")]
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

        [Authorize]
        [HttpGet ("/v1/marvel/comic/search")]
        public async Task<IEnumerable<Comic>> GetComicByTitleAndIssue ([FromQuery] string title, string issueNumber) {
            _logger.LogDebug ("Request received with parameters: \ntitle: {title}\nissueNumber: {issueNumber}", title, issueNumber);

            var comicResponse = await _getMarvelComic.GetByTitleAndIssueNumber (title, issueNumber) as IEnumerable<Comic>;

            _logger.LogDebug ("Found {number} comics", comicResponse.Count ());

            return comicResponse;
        }
    }
}