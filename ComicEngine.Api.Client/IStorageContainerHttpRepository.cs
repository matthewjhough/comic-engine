using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Client
{
    public interface IStorageContainerHttpRepository
    {
        Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer, string userId);
    }
}