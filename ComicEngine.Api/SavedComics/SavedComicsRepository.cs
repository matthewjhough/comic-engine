using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using ComicEngine.Data.SavedComics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComicEngine.Api.SavedComics {
    public class SavedComicsRepository : ISavedComicsRepository {
        private readonly SavedComicContext _savedComicContext;

        public SavedComicsRepository (IConfiguration configuration) {
            _savedComicContext = new SavedComicContext (configuration);
        }

        public async Task CreateSavedComic (Comic comic) {
            // Todo: add logging.
            try {
                await _savedComicContext.AddAsync (comic);
                await _savedComicContext.SaveChangesAsync ();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<IEnumerable<Comic>> GetSavedComics () {
            // Todo: add logging.
            var savedComics = await _savedComicContext.Comics
                .Include (x => x.Characters)
                .ThenInclude (c => c.Items)
                .Include (x => x.Creators)
                .ThenInclude (c => c.Items)
                .Include ("Series")
                .Include ("PublishDates")
                .Include ("RelevantLinks")
                .ToListAsync ();

            return savedComics;
        }
    }
}