using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.SavedComic;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.Server.Comics {
    // FIXME: Update to single execution commands.
    public class ComicCommands : IGetSavedComicCommand, ICreateSavedComicCommand {
        private readonly IComicsRepository _comicsRepository;

        public ComicCommands (IComicsRepository comicsRepository) {
            _comicsRepository = comicsRepository;
        }

        public async Task<Comic> CreateSavedComicAsync (Comic comic, string subject)
        {
            // Todo: add logging.
            await _comicsRepository.CreateSavedComic (comic, subject);
            return comic;
        }

        public async Task<IEnumerable<Comic>> GetSavedComics (string subject) {
            // Todo: add logging.
            var savedComics = await _comicsRepository.GetSavedComics (subject);

            return savedComics;
        }
    }
}