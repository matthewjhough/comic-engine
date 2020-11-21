using ComicEngine.Data.StorageContainers;

namespace ComicEngine.Data.MongoDb.StorageContainers
{
    public class StorageContainerDatabaseSettings : IStorageContainerDatabaseSettings
    {
        public string StorageContainerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}