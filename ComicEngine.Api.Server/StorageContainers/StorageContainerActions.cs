using System;
using System.Threading.Tasks;
using ComicEngine.Api.Server.Actions.StorageContainers;
using ComicEngine.Data.StorageContainers;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Api.Server.StorageContainers
{
    public class StorageContainerActions : ICreateStorageContainerAction
    {
        private readonly IStorageContainersRepository _storageContainersRepository;
        
        public StorageContainerActions(IStorageContainersRepository storageContainersRepository)
        {
            _storageContainersRepository = storageContainersRepository
                ?? throw new ArgumentNullException(nameof(storageContainersRepository));
        }

        public async Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer)
        {
            // TODO: VALIDATE RESOURCE
            var createdStorageContainer = await _storageContainersRepository.CreateStorageContainer(storageContainer);

            return createdStorageContainer;
        }
    }
}