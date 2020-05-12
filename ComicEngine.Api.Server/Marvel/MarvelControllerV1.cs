using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Marvel.Commands;
using ComicEngine.Common.Comic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Controllers {
    [ApiController]
    public class MarvelControllerV1 : ControllerBase {
        private readonly ILogger _logger;

        private IGetMarvelCommand _getMarvel;

        /// <summary>
        /// Constructor for <see cref="MarvelControllerV1" />
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="marvelService"></param>
        public MarvelControllerV1 (
            ILogger<MarvelControllerV1> logger,
            IGetMarvelCommand getMarvelCommand) {

            _getMarvel = getMarvelCommand;
            _logger = logger;
        }

        /// <summary>
        /// Returns a marvel comic that matches upc submitted.
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        [HttpGet ("/v1/marvel/comic")]
        public async Task<Comic> GetComicByUpc ([FromQuery] string upc) {
            _logger.LogDebug ("Request received with upc code: {upc}", upc);

            if (upc is null) {
                _logger.LogDebug ("UPC cannot be a null value.", upc);
                throw new ArgumentNullException ();
            }

            Comic comicResponse = await _getMarvel.GetByCode (upc);

            _logger.LogDebug ("Returning comic: {marvelResponse}", comicResponse?.Title);

            return comicResponse;
        }

        [HttpGet ("/v1/marvel/comic/search")]
        public async Task<IEnumerable<Comic>> GetComicByTitleAndIssue ([FromQuery] string title, string issueNumber) {
            _logger.LogDebug ("Request received with parameters: \ntitle: {title}\nissueNumber: {issueNumber}", title, issueNumber);

            var comicResponse = await _getMarvel.GetByTitleAndIssueNumber (title, issueNumber) as IEnumerable<Comic>;

            _logger.LogDebug ("Found {number} comics", comicResponse.Count ());

            return comicResponse;
        }
    }
}