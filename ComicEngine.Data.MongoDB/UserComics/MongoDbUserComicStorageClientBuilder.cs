namespace ComicEngine.Data.MongoDb.UserComics
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