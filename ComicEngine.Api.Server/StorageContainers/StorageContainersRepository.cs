using System.Threading.Tasks;
using ComicEngine.Data.StorageContainers;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Server.StorageContainers
{
    public class StorageContainersRepository : IStorageContainersRepository
    {
        internal StorageContainersRepository()
        {
        }

        public Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer)
        {
            throw new System.NotImplementedException();
        }
    }
}