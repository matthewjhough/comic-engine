namespace ComicEngine.Data.StorageContainers
{
    public interface IStorageContainerDatabaseSettings
    {
        string StorageContainersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}