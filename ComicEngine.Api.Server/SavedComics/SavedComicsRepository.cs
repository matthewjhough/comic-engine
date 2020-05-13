using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Data.MsSql.Comics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComicEngine.Api.Server.SavedComics {
    public class SavedComicsRepository : ISavedComicsRepository {
        private readonly ComicContext _comicContext;

        private string _fakeUserId = "12345";

        public SavedComicsRepository (IConfiguration configuration) {
            _comicContext = new ComicContext (configuration);
        }

        public async Task CreateSavedComic (Comic comic) {
            var persistedComic = new PersistedComic () {
                Comic = comic,
                UserId = _fakeUserId
            };

            // Todo: add logging.
            try {
                await _comicContext.AddAsync (persistedComic);
                await _comicContext.SaveChangesAsync ();
            } catch (Exception ex) {
                // TODO: add logging
                throw ex;
            }
        }

        public async Task<IEnumerable<Comic>> GetSavedComics () {
            // Todo: add logging.
            // TODO: move to this to storage client, and convert within repo level
            var persistedComics = await _comicContext.PersistedComics
                .Include (x => x.Comic)
                .ThenInclude (x => x.Characters)
                .ThenInclude (x => x.Items)
                .Include (x => x.Comic)
                .ThenInclude (x => x.Creators)
                .ThenInclude (x => x.Items)
                .Include (x => x.Comic)
                .ThenInclude (x => x.PublishDates)
                .Include (x => x.Comic)
                .ThenInclude (x => x.RelevantLinks)
                .Include (x => x.Comic)
                .ThenInclude (x => x.Series)
                .Include (x => x.Comic)
                .ToListAsync ();

            return persistedComics
                .Where (persistedComic =>
                    string.Equals (persistedComic.UserId, _fakeUserId))
                .Select (persistedComic => persistedComic.Comic);
        }
    }
}