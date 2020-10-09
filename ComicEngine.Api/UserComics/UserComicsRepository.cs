using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Data;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.UserComics {
    public class UserComicsRepository : IUserComicsRepository {

        internal IStorageClient<Comic> ComicStorageClient;

        internal ILogger Logger;

        internal UserComicsRepository () {}

        public async Task CreateSavedComic (Comic comic, string subject)
        {
            Logger.LogDebug("Adding comic with id: '{comicId}' for user: '{userId}'",
                comic.Id, subject);
            await ComicStorageClient.Create(comic, subject);
        }

        public async Task<IEnumerable<Comic>> GetSavedComics (string subject) {
            var comics = await ComicStorageClient.Get(subject);
            return comics;
        }
    }
}