using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using Microsoft.AspNetCore.Mvc;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicsControllerV1 : ControllerBase {
        private readonly ISavedComicsService _savedComicsService;

        public SavedComicsControllerV1 (ISavedComicsService savedComicsService) {
            _savedComicsService = savedComicsService;
        }

        [HttpPost ("/v1/saved/comics")]
        public async Task<Comic> Create ([FromBody] Comic comic) {
            // Todo: add logging/exception handling
            var saveComic = await _savedComicsService.CreateSavedComicAsync (comic);

            return comic;
        }

        [HttpGet ("/v1/saved/comics")]
        public async Task<IEnumerable<Comic>> Get () {
            // Todo: add logging / exception handling
            var comicList = await _savedComicsService.GetSavedComics ();

            return comicList;
        }
    }
}