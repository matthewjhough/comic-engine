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

        public SavedComicsRepository (IConfiguration configuration) {
            _comicContext = new ComicContext (configuration);
        }

        public async Task CreateSavedComic (Comic comic) {
            // Todo: add logging.
            try {
                await _comicContext.AddAsync (comic);
                await _comicContext.SaveChangesAsync ();
            } catch (Exception ex) {
                // TODO: add logging
                throw ex;
            }
        }

        public async Task<IEnumerable<Comic>> GetSavedComics () {
            // Todo: add logging.
            // TODO: move to this to storage client, and convert within repo level
            var persistedComic = await _comicContext.PersistedComics
                .Include (x => x.Comic)
                // .ThenInclude (x => x.Characters)
                // .ThenInclude (c => c.Items)
                // .Include (x => x.Creators)
                // .ThenInclude (c => c.Items)
                // .Include ("Series")
                // .Include ("PublishDates")
                // .Include ("RelevantLinks")
                .ToListAsync ();

            return new List<Comic> ();
        }
    }
}