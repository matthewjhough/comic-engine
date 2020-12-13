using System.Threading.Tasks;
using ComicEngine.Api.Server.Actions.StorageContainers;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Server.StorageContainers
{
    public class StorageContainerActions : ICreateStorageContainerAction
    {
        public StorageContainerActions()
        {
            
        }

        public Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer)
        {
            throw new System.NotImplementedException();
        }
    }
}