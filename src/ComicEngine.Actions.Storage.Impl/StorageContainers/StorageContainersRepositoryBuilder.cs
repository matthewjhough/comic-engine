using ComicEngine.Data;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Actions.Impl.StorageContainers
{
    public class StorageContainersRepositoryBuilder
    {
        internal IStorageClient<StorageContainer> StorageClient;
        
        public StorageContainersRepositoryBuilder()
        {
        }
        
        public StorageContainersRepositoryBuilder WithStorageClient(IStorageClient<StorageContainer> storageClient)
        {
            StorageClient = storageClient;
            return this;
        }

        public StorageContainersRepository Build()
        {
            return new StorageContainersRepository()
            {
                StorageClient = StorageClient
            };
        }
    }
}