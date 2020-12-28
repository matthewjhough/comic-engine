using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Client.StorageContainers
{
    public interface IStorageContainerHttpRepository
    {
        Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer);

        Task<IEnumerable<StorageContainer>> GetStorageContainers(string subject);
    }
}