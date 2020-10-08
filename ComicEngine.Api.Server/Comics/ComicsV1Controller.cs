using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.SavedComic;
using ComicEngine.Common.Comic;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Comics {
    [ApiController]
    [Authorize]
    public class ComicsV1Controller : ControllerBase {
        private readonly ICreateSavedComicCommand _createCommand;
        private readonly IGetSavedComicCommand _getCommand;
        private readonly ILogger _logger;

        public ComicsV1Controller (
            ICreateSavedComicCommand createSavedComicsCommand,
            IGetSavedComicCommand getSavedComicsCommand,
            ILogger<ComicsV1Controller> logger
        ) {
            _createCommand = createSavedComicsCommand;
            _getCommand = getSavedComicsCommand;
            _logger = logger;
        }

        [HttpPost ("/v1/saved/comics/{userId}")]
        public async Task<Comic> Create ([FromBody] Comic comic, [FromRoute] string userId) {
            // TODO: Validation
            if (comic.Title is null) {
                throw new Exception ("Title is required.");
            }
            
            _logger.LogDebug ("**** Comic from body title: {title} ****", comic.Title);
            
            // Todo: add logging/exception handling
            var saveComic = await _createCommand.CreateSavedComicAsync (comic, userId);

            return saveComic;
        }

        [HttpPost ("/v1/saved/comics/temp")]
        public async Task<Comic> CreateFromBody ([FromBody] Comic comic) {
            // TODO: This info should be included in access_token.
            var subject = "1234";
            _logger.LogDebug ("Comic from body title: {title}", comic.Title);
            
            // Todo: add logging/exception handling
            var saveComic = await _createCommand.CreateSavedComicAsync (comic, subject);

            return saveComic;
        }

        [Authorize]
        [HttpGet ("/v1/saved/comics/{userId}")]
        public async Task<IEnumerable<Comic>> Get ([FromRoute] string userId)
        {
            _logger.LogDebug("Retrieving comics for user '{userId}'", userId);
            var test = HttpContext;
            // Todo: add logging / exception handling
            var comicList = await _getCommand.GetSavedComics (userId);
            var comicEnumeration = comicList as Comic[] ?? comicList.ToArray();
            _logger.LogDebug("Found '{comicCount}' comics for user '{userId}'", comicEnumeration.Count(), userId);
            
            return comicEnumeration;
        }
    }
}