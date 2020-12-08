using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Api.Commands.UserComics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Api.UserComics {
    // FIXME: Update to single execution commands.
    public class UserComicCommands : IGetUserComicCommand, IDeleteUserComicCommand {
        private readonly IUserComicsRepository _userComicsRepository;

        internal UserComicCommands (IUserComicsRepository userComicsRepository) {
            _userComicsRepository = userComicsRepository;
        }

        public async Task<IEnumerable<UserComic>> GetUserComics (string subject) {
            // Todo: add logging.
            var userComics = await _userComicsRepository.GetUserComics (subject);

            return userComics;
        }

        public async Task<bool> DeleteUserComic(string userComicId, string subject)
        {
            return await _userComicsRepository.DeleteUserComic(userComicId, subject);
        }
    }
}