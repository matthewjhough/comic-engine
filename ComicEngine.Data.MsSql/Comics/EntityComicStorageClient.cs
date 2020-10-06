using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using Microsoft.EntityFrameworkCore;

namespace ComicEngine.Data.MsSql.Comics {
    public class EntityComicStorageClient : IStorageClient<Comic>
    {
        internal ComicContext ComicContext;

        public async Task Create(Comic resource, string subject)
        {
            var persistedComic = new PersistedComic {
                Comic = resource,
                UserId = subject
            };
            
            persistedComic.SetCreatedFields(subject);

            // Todo: add logging.
            try {
                await ComicContext.AddAsync (persistedComic);
                await ComicContext.SaveChangesAsync ();
            } catch (Exception ex) {
                // TODO: add logging
                throw;
            }
        }

        public async Task<IEnumerable<Comic>> Get(string subject)
        {
            // Todo: add logging.
            var persistedComics = await ComicContext.PersistedComics
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

            var comics = persistedComics
                .Where(persistedComic =>
                    string.Equals(persistedComic.UserId, subject))
                .Select(persistedComic => persistedComic.Comic);

            return comics;
        }

        public Task<bool> Delete(string resourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Comic> Update(string resourceId, Comic resource)
        {
            throw new System.NotImplementedException();
        }

        public Task<Comic> GetByResourceId(string resourceId)
        {
            throw new System.NotImplementedException();
        }
    }
}