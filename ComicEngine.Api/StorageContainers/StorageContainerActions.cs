using System.Threading.Tasks;
using ComicEngine.Api.Actions.StorageContainers;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.StorageContainers
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