using ComicEngine.Data.UserComics;

namespace ComicEngine.Data.MongoDb.Impl.UserComics
{
    public class MongoDbUserComicStorageClientBuilder
    {
        private IUserComicsDatabaseSettings UserComicsDatabaseSettings { get; set; }

        public MongoDbUserComicStorageClientBuilder WithDatabaseSettings(IUserComicsDatabaseSettings settings)
        {
            UserComicsDatabaseSettings = settings;
            return this;
        }
        
        public MongoDbUserComicStorageClient Build()
        {
            return new MongoDbUserComicStorageClient(UserComicsDatabaseSettings);
        }
    }
}