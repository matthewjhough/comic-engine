using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Marvel;
using ComicEngine.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Controllers {
    [ApiController]
    public class MarvelControllerV1 : ControllerBase {
        private readonly ILogger _logger;

        private IMarvelService _marvelService;

        /// <summary>
        /// Constructor for <see cref="MarvelControllerV1" />
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="marvelService"></param>
        public MarvelControllerV1 (
            ILogger<MarvelControllerV1> logger,
            IMarvelService marvelService) {

            _marvelService = marvelService;
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

            Comic comicResponse = await _marvelService.GetByCode (upc);

            _logger.LogDebug ("Returning comic: {marvelResponse}", comicResponse?.Title);

            return comicResponse;
        }

        [HttpGet ("/v1/marvel/comic/search")]
        public async Task<List<Comic>> GetComicByTitleAndIssue ([FromQuery] string title, string issueNumber) {
            _logger.LogDebug ("Request received with parameters: \ntitle: {title}\nissueNumber: {issueNumber}", title, issueNumber);

            var comicResponse = await _marvelService.GetByTitleAndIssueNumber (title, issueNumber) as List<Comic>;

            _logger.LogDebug ("Found {number} comics", comicResponse.Count ());

            return comicResponse;
        }
    }
}