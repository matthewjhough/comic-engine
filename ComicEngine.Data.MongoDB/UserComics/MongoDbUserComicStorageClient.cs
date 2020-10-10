using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Common.Comic;
using MongoDB.Driver;

namespace ComicEngine.Data.MongoDb.UserComics
{
    public class MongoDbUserComicStorageClient : IStorageClient<Comic>
    {
        private readonly IMongoCollection<PersistedMongoDbUserComic> _userComics;
        
        internal IUserComicsDatabaseSettings Settings { get; set; }
        
        internal MongoDbUserComicStorageClient()
        {
            var client = new MongoClient(Settings.ConnectionString);
            var database = client.GetDatabase(Settings.DatabaseName);
            _userComics = database
                .GetCollection<PersistedMongoDbUserComic>(Settings
                    .UserComicsCollectionName);
        }
        
        public async Task Create(Comic resource, string subject)
        {
            var persistedComic = new PersistedMongoDbUserComic() {
                Comic = resource,
                UserId = subject
            };
            
            await _userComics.InsertOneAsync(persistedComic);
        }

        public async Task<IEnumerable<Comic>> Get(string subject)
        {
            var persistedComics = await _userComics
                .FindAsync(comic => string.Equals(comic.UserId, subject));
            
            var comics = persistedComics
                .ToList()
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

        // TODO: Implement single item
        public PersistedMongoDbUserComic Get(int id) =>
            _userComics
                .Find<PersistedMongoDbUserComic>(comic => comic.Id == id)
                .FirstOrDefault();

        // public void Update(int id, Comic comicIn) =>
        //     _userComics.ReplaceOne(comic => comic.Id == id, comicIn);
        //
        // public void Remove(Comic comicIn) =>
        //     _userComics.DeleteOne(comic => comic.Id == comicIn.Id);
        //
        // public void Remove(int id) => 
        //     _userComics.DeleteOne(comic => comic.Id == id);

    }
}