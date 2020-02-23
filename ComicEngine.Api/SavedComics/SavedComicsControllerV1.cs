using System.Threading.Tasks;
using ComicEngine.Common;
using Microsoft.AspNetCore.Mvc;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicsControllerV1 : ControllerBase {
        private readonly ISavedComicsService _savedComicsService;

        public SavedComicsControllerV1 (ISavedComicsService savedComicsService) {
            _savedComicsService = savedComicsService;
        }

        [HttpPost ("/v1/saved/comic")]
        public async Task<Comic> Create ([FromBody] Comic comic) {
            var saveComic = await _savedComicsService.CreateSavedComicAsync (comic);

            return comic;
        }
    }
}