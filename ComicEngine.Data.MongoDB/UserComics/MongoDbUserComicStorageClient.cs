using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Common.UserComics;
using ComicEngine.Data.UserComics;
using MongoDB.Driver;

namespace ComicEngine.Data.MongoDb.UserComics
{
    public class MongoDbUserComicStorageClient : IStorageClient<UserComic>
    {
        private readonly IMongoCollection<PersistedMongoDbUserComic> _userComics;
        
        internal MongoDbUserComicStorageClient(IUserComicsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _userComics = database
                .GetCollection<PersistedMongoDbUserComic>(settings
                    .UserComicsCollectionName);
        }

        public async Task<UserComic> Create(UserComic resource, string subject)
        {
            var persistedComic = new PersistedMongoDbUserComic() {
                UserComic = resource
            };
            
            await _userComics.InsertOneAsync(persistedComic);

            return resource;
        }

        public async Task<IEnumerable<UserComic>> Get(string subject)
        {
            var persistedComics = await _userComics
                .FindAsync(comic => string.Equals(comic.UserComic.UserId, subject));
            
            var comics = persistedComics
                .ToList()
                .Where(persistedComic =>
                    string.Equals(persistedComic.UserComic.UserId, subject))
                .Select(persistedComic => persistedComic.UserComic);
            
            return comics;
        }
        
        public Task<bool> Delete(string resourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserComic> Update(string resourceId, UserComic resource)
        {
            throw new System.NotImplementedException();
        }

        // TODO: Implement single item
        public PersistedMongoDbUserComic GetById(string id) =>
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