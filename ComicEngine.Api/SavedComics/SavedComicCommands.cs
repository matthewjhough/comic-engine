using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.SavedComics {
    // FIXME: Update to single execution commands.
    public class SavedComicCommands : IGetSavedComicCommand, ICreateSavedComicCommand {
        private readonly ISavedComicsRepository _savedComicsRepository;

        public SavedComicCommands (ISavedComicsRepository savedComicsRepository) {
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