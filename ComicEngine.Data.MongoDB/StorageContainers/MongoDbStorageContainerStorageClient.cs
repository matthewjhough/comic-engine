using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Data.MongoDb.UserComics;
using ComicEngine.Data.StorageContainers;
using ComicEngine.Shared.StorageContainers;
using MongoDB.Driver;

namespace ComicEngine.Data.MongoDb.StorageContainers
{
    public class MongoDbStorageContainerStorageClient : IStorageClient<StorageContainer>
    {
        private readonly IMongoCollection<PersistedMongoDbStorageContainer> _storageContainers;
        internal MongoDbStorageContainerStorageClient(IStorageContainerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _storageContainers = database
                .GetCollection<PersistedMongoDbStorageContainer>(settings.StorageContainersCollectionName);
        }
        
        public async Task<StorageContainer> Create(StorageContainer resource, string subject)
        {
            var persistedResource = new PersistedMongoDbStorageContainer()
            {
                StorageContainer = resource,
            };
            
            await _storageContainers.InsertOneAsync(persistedResource);

            resource.Id = persistedResource.Id;
            
            return resource;
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