using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Data;
using ComicEngine.Data.StorageContainers;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Server.StorageContainers
{
    public class StorageContainersRepository : IStorageContainersRepository
    {
        internal IStorageClient<StorageContainer> StorageClient;

        // internal ILogger Logger = ApplicationLogging.CreateLogger(nameof(StorageContainersRepository));
        
        internal StorageContainersRepository()
        {
        }

        public async Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer)
        {
            // Logger.LogDebug(
            //     "Saving storage container '{label}' for user '{userId}'",
            //     storageContainer.Label,
            //     storageContainer.UserId);
            
            var createdStorageContainer = await StorageClient.Create(storageContainer, storageContainer.UserId);

            // Logger.LogDebug(
            //     "Saved storage container '{label}' for user '{userId}'",
            //     createdStorageContainer.Label,
            //     createdStorageContainer.UserId);
            
            return createdStorageContainer;
        }

        public async Task<IEnumerable<StorageContainer>> GetStorageContainers(string subject)
        {
            var storageContainers = await StorageClient.Get(subject);

            return storageContainers;
        }
    }
}