using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Common;
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

        public IEnumerable<Comic> GetSavedComics () {
            // Todo: add logging.
            var savedComics = _savedComicContext.Comics
                .Select (x => x)
                .ToList ();

            return savedComics;
        }
    }
}