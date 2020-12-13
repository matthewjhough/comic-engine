using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Data;
using ComicEngine.Data.UserComics;
using ComicEngine.Shared.UserComics;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.UserComics {
    public class UserComicsRepository : IUserComicsRepository {

        internal IStorageClient<UserComic> ComicStorageClient;

        internal ILogger Logger;

        internal UserComicsRepository () {}

        public async Task<UserComic> CreateUserComic (UserComic comic, string subject)
        {
            await ComicStorageClient.Create(comic, subject);

            return comic;
        }

        public async Task<IEnumerable<UserComic>> GetUserComics (string subject) {
            var userComics = await ComicStorageClient.Get(subject);
            
            return userComics;
        }

        public async Task<bool> DeleteUserComic(string userComicId, string subject)
        {
            return await ComicStorageClient.Delete(userComicId);
        }
    }
}