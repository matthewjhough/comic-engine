using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Actions.StorageContainers
{
    public interface IGetStorageContainersAction
    {
        Task<IEnumerable<StorageContainer>> GetStorageContainers(string subject);
    }
}