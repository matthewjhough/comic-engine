using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Actions.StorageContainers
{
    public interface ICreateStorageContainerAction
    {
        Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer);
    }
}