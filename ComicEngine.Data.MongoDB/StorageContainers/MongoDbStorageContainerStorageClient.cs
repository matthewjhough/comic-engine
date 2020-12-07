using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Data.MongoDb.StorageContainers
{
    public class MongoDbStorageContainerStorageClient : IStorageClient<StorageContainer>
    {
        public Task<StorageContainer> Create(StorageContainer resource, string subject)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<StorageContainer>> Get(string subject)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(string resourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<StorageContainer> Update(string resourceId, StorageContainer resource)
        {
            throw new System.NotImplementedException();
        }
    }
}