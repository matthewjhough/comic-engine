using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Server.Actions.StorageContainers
{
    public interface ICreateStorageContainerAction
    {
        Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer);
    }
}