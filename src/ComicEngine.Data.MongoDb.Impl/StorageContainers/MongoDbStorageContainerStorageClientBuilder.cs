using ComicEngine.Data.StorageContainers;

namespace ComicEngine.Data.MongoDb.Impl.StorageContainers
{
    public class MongoDbStorageContainerStorageClientBuilder
    {
        private IStorageContainerDatabaseSettings StorageContainerDatabaseSettings { get; set; }
        
        // TODO: WithMongoCollection method

        public MongoDbStorageContainerStorageClientBuilder WithDatabaseSettings(IStorageContainerDatabaseSettings settings)
        {
            StorageContainerDatabaseSettings = settings;
            return this;
        }
        
        public MongoDbStorageContainerStorageClient Build()
        {
            return new MongoDbStorageContainerStorageClient(StorageContainerDatabaseSettings);
        }
    }
}