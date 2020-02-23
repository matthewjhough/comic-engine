using System;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicsService : ISavedComicsService {
        private readonly ISavedComicsRepository _savedComicsRepository;

        public SavedComicsService (ISavedComicsRepository savedComicsRepository) {
            _savedComicsRepository = savedComicsRepository;
        }

        public async Task<Comic> AddComicAsync (Comic comic) {

            try {
                await _savedComicsRepository.SaveComic (comic);
                return comic;
            } catch (Exception exceptionFromAdding) {
                throw exceptionFromAdding;
            }
        }
    }
}