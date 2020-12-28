using ComicEngine.Data.StorageContainers;

namespace ComicEngine.Data.MongoDb.Impl.StorageContainers
{
    public class StorageContainerDatabaseSettings : IStorageContainerDatabaseSettings
    {
        public string StorageContainersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}