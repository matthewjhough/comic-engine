using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Marvel;
using ComicEngine.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

/// <summary>
/// TODO:
/// Phase 1:
/// /// Add Graphql (Client) - DONE
/// /// Add Barcode Scanner (Client) - DONE
/// /// Refactor and cleanup API controller - DONE
/// /// Style barcode reader (Client) - DONE
/// Move API keys to configuration, remove from git (API)
/// /// Make/Add Request with barcode (API) - DONE
/// /// Display response data (Client) - DONE
/// /// Add filterBy UPC (API)
/// /// Add Logging (API)
/// 
/// Phase 2:
/// Add authentication (API)
/// Setup Package for individual comic management (API)
///     > Add SavedComic model class
///     > GET all stored comics from user
/// Take Response data from marvel, store in database w/ user id (API)
/// Display stored & scanned comics (Client)
/// Add Logging (Client)
/// </summary>

namespace ComicEngine.Api.Controllers {
    [ApiController]
    public class MarvelControllerV1 : ControllerBase {

        private MarvelHttpClientV1 _marvelHttpClient;
        private readonly ILogger _logger;

        public MarvelControllerV1 (MarvelHttpClientV1 marvelHttpClient, ILogger<MarvelControllerV1> logger) {
            _marvelHttpClient = marvelHttpClient;
            _logger = logger;
        }

        /// <summary>
        /// Returns a marvel response containing #### of comics
        /// </summary>
        /// <returns></returns>
        [HttpGet ("/marvel")]
        public async Task<MarvelResponse> GetComics () {
            var marvelResponse = await _marvelHttpClient.GetAllComics ();

            return marvelResponse;
        }

        /// <summary>
        /// Returns a marvel comic that matches upc submitted.
        /// </summary>
        /// <param name="upc"></param>
        /// <returns></returns>
        [HttpGet ("/marvel/comic")]
        public async Task<Comic> GetComicByUpc ([FromQuery] string upc) {
            _logger.LogDebug ("Request received with upc code: {upc}", upc);

            Comic comicResponse = await _marvelHttpClient.GetByCode (upc);

            _logger.LogDebug ("Returning comic: {marvelResponse}", comicResponse?.Title);

            return comicResponse;
        }

        [HttpGet ("/marvel/comic/search")]
        public async Task<List<Comic>> GetComicByTitleAndIssue ([FromQuery] string title, string issueNumber) {
            _logger.LogDebug ("Request received with parameters: \ntitle: {title}\nissueNumber: {issueNumber}", title, issueNumber);

            var comicResponse = await _marvelHttpClient.GetByTitleAndIssueNumber (title, issueNumber) as List<Comic>;

            _logger.LogDebug ("Found {number} comics", comicResponse.Count ());

            return comicResponse;
        }
    }
}