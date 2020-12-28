using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Actions.UserComics;
using ComicEngine.Data.UserComics;
using ComicEngine.Shared.UserComics;

namespace ComicEngine.Actions.Impl.UserComics {
    public class UserComicActions : IGetUserComicAction, IDeleteUserComicAction {
        private readonly IUserComicsRepository _userComicsRepository;

        public UserComicActions (IUserComicsRepository userComicsRepository) {
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