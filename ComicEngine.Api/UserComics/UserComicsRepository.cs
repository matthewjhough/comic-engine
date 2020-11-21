using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comics;
using ComicEngine.Data;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.UserComics {
    public class UserComicsRepository : IUserComicsRepository {

        internal IStorageClient<Comic> ComicStorageClient;

        internal ILogger Logger;

        internal UserComicsRepository () {}

        public async Task<Comic> CreateUserComic (Comic comic, string subject)
        {
            Logger.LogDebug("Adding comic with id: '{comicId}' for user: '{userId}'",
                comic.Id, subject);
            await ComicStorageClient.Create(comic, subject);

            return comic;
        }

        public async Task<IEnumerable<Comic>> GetUserComics (string subject) {
            var comics = await ComicStorageClient.Get(subject);
            return comics;
        }
    }
}