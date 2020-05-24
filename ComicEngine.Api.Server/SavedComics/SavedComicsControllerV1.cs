using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.SavedComics;
using ComicEngine.Common.Comic;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.SavedComics {
    public class SavedComicsControllerV1 : ControllerBase {
        private readonly ICreateSavedComicCommand _createCommand;
        private readonly IGetSavedComicCommand _getCommand;
        private readonly ILogger _logger;

        public SavedComicsControllerV1 (
            ICreateSavedComicCommand createSavedComicsCommand,
            IGetSavedComicCommand getSavedComicsCommand,
            ILogger<SavedComicsControllerV1> logger
        ) {
            _createCommand = createSavedComicsCommand;
            _getCommand = getSavedComicsCommand;
            _logger = logger;
        }

        [HttpPost ("/v1/saved/comics")]
        public async Task<Comic> Create ([FromBody] Comic comic) {
            var context = HttpContext;
            // TODO: Validation
            if (comic.Title is null) {
                throw new Exception ("Title is required.");
            }
            _logger.LogDebug ("**** Comic from body title: {title} ****", comic.Title);
            // Todo: add logging/exception handling
            var saveComic = await _createCommand.CreateSavedComicAsync (comic);

            return comic;
        }

        [HttpPost ("/v1/saved/comics/temp")]
        public async Task<Comic> CreateFromBody ([FromBody] Comic comic) {
            _logger.LogDebug ("Comic from body title: {title}", comic.Title);
            // Todo: add logging/exception handling
            var saveComic = await _createCommand.CreateSavedComicAsync (comic);

            return comic;
        }

        [HttpGet ("/v1/saved/comics")]
        [Authorize]
        public async Task<IEnumerable<Comic>> Get () 
        {
            // Todo: add logging / exception handling
            var comicList = await _getCommand.GetSavedComics ();

            return comicList;
        }
    }
}