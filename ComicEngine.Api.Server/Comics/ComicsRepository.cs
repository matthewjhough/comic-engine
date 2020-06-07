using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Data;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Comics {
    public class ComicsRepository : IComicsRepository {

        internal IStorageClient<Comic> ComicStorageClient;

        internal ILogger Logger;

        internal ComicsRepository () {}

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