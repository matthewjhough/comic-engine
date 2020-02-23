using System;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicsService : ISavedComicsService {
        private readonly ISavedComicsRepository _savedComicsRepository;

        public SavedComicsService (ISavedComicsRepository savedComicsRepository) {
            _savedComicsRepository = savedComicsRepository;
        }

        public async Task<Comic> CreateSavedComicAsync (Comic comic) {

            try {
                await _savedComicsRepository.CreateSavedComic (comic);
                return comic;
            } catch (Exception exceptionFromAdding) {
                throw exceptionFromAdding;
            }
        }
    }
}