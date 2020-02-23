using System;
using System.Collections.Generic;
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
            try {
                await _savedComicContext.AddAsync (comic);
                await _savedComicContext.SaveChangesAsync ();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public Task<IEnumerable<Comic>> GetSavedComics () {
            throw new NotImplementedException ();
        }
    }
}