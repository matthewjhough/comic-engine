using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Common.Comics;
using Microsoft.EntityFrameworkCore;

namespace ComicEngine.Data.MsSql.UserComics {
    public class EntityUserComicStorageClient : IStorageClient<Comic>
    {
        internal UserComicContext UserComicContext;

        public async Task<Comic> Create(Comic resource, string subject)
        {
            var persistedComic = new PersistedMsSqlUserComic {
                Comic = resource,
                UserId = subject
            };
            
            persistedComic.SetCreatedFields(subject);

            // Todo: add logging.
            try {
                await UserComicContext.AddAsync (persistedComic);
                await UserComicContext.SaveChangesAsync ();
            } catch (Exception ex) {
                // TODO: add logging
                throw;
            }

            return resource;
        }

        public async Task<IEnumerable<Comic>> Get(string subject)
        {
            // Todo: add logging.
            var persistedComics = await UserComicContext.PersistedComics
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
    }
}