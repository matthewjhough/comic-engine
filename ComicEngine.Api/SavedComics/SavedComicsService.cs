using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicsService : ISavedComicsService {
        private readonly ISavedComicsRepository _savedComicsRepository;

        public SavedComicsService (ISavedComicsRepository savedComicsRepository) {
            _savedComicsRepository = savedComicsRepository;
        }

        public async Task<Comic> CreateSavedComicAsync (Comic comic) {
            // Todo: add logging.
            try {
                await _savedComicsRepository.CreateSavedComic (comic);
                return comic;
            } catch (Exception exceptionFromAdding) {
                throw exceptionFromAdding;
            }
        }

        public async Task<IEnumerable<Comic>> GetSavedComics () {
            // Todo: add logging.
            var savedComics = await _savedComicsRepository.GetSavedComics ();

            return savedComics;
        }
    }
}