using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Data.StorageContainers
{
    public interface IStorageContainersRepository : IDataRepository
    {
        Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer);
    }
}