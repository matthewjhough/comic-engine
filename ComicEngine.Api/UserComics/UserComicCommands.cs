using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.UserComic;
using ComicEngine.Common.Comic;

namespace ComicEngine.Api.UserComics {
    // FIXME: Update to single execution commands.
    public class UserComicCommands : IGetUserComicCommand, ICreateUserComicCommand {
        private readonly IUserComicsRepository _userComicsRepository;

        public UserComicCommands (IUserComicsRepository userComicsRepository) {
            _userComicsRepository = userComicsRepository;
        }

        public async Task<Comic> CreateUserComicAsync (Comic comic, string subject)
        {
            // Todo: add logging.
            await _userComicsRepository.CreateSavedComic (comic, subject);
            return comic;
        }

        public async Task<IEnumerable<Comic>> GetUserComics (string subject) {
            // Todo: add logging.
            var savedComics = await _userComicsRepository.GetSavedComics (subject);

            return savedComics;
        }
    }
}