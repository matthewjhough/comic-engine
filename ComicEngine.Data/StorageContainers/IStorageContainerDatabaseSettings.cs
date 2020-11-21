namespace ComicEngine.Data.StorageContainers
{
    public interface IStorageContainerDatabaseSettings
    {
        string StorageContainerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}