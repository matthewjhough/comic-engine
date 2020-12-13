using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Server.Actions.StorageContainers
{
    public interface IGetStorageContainersAction
    {
        Task<IEnumerable<StorageContainer>> GetStorageContainers(string subject);
    }
}