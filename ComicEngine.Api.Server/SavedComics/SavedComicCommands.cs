using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.SavedComic;
using ComicEngine.Common;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.Server.SavedComics {
    // FIXME: Update to single execution commands.
    public class SavedComicCommands : IGetSavedComicCommand, ICreateSavedComicCommand {
        private readonly ISavedComicsRepository _savedComicsRepository;

        public SavedComicCommands (ISavedComicsRepository savedComicsRepository) {
            _savedComicsRepository = savedComicsRepository;
        }

        public async Task<Comic> CreateSavedComicAsync (Comic comic, string subject) {
            // Todo: add logging.
            try {
                await _savedComicsRepository.CreateSavedComic (comic, subject);
                return comic;
            } catch (Exception exceptionFromAdding) {
                throw exceptionFromAdding;
            }
        }

        public async Task<IEnumerable<Comic>> GetSavedComics (string subject) {
            // Todo: add logging.
            var savedComics = await _savedComicsRepository.GetSavedComics (subject);

            return savedComics;
        }
    }
}