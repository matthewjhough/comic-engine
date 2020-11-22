using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.UserComics;
using ComicEngine.Common.UserComics;

namespace ComicEngine.Api.UserComics {
    // FIXME: Update to single execution commands.
    public class UserComicCommands : IGetUserComicCommand {
        private readonly IUserComicsRepository _userComicsRepository;

        internal UserComicCommands (IUserComicsRepository userComicsRepository) {
            _userComicsRepository = userComicsRepository;
        }

        public async Task<IEnumerable<UserComic>> GetUserComics (string subject) {
            // Todo: add logging.
            var userComics = await _userComicsRepository.GetUserComics (subject);

            return userComics;
        }
    }
}