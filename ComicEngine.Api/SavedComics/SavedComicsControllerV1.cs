using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.SavedComics.Commands;
using ComicEngine.Common;
using ComicEngine.Common.Comic;
using Microsoft.AspNetCore.Mvc;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicsControllerV1 : ControllerBase {
        private readonly ICreateSavedComicCommand _createCommand;
        private readonly IGetSavedComicCommand _getCommand;

        public SavedComicsControllerV1 (
            ICreateSavedComicCommand createSavedComicsCommand,
            IGetSavedComicCommand getSavedComicsCommand
        ) {
            _createCommand = createSavedComicsCommand;
            _getCommand = getSavedComicsCommand;
        }

        [HttpPost ("/v1/saved/comics")]
        public async Task<Comic> Create ([FromBody] Comic comic) {
            // Todo: add logging/exception handling
            var saveComic = await _createCommand.CreateSavedComicAsync (comic);

            return comic;
        }

        [HttpGet ("/v1/saved/comics")]
        public async Task<IEnumerable<Comic>> Get () {
            // Todo: add logging / exception handling
            var comicList = await _getCommand.GetSavedComics ();

            return comicList;
        }
    }
}