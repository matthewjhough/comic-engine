using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComicEngine.Actions.StorageContainers;
using ComicEngine.Data.StorageContainers;
using ComicEngine.Shared.StorageContainers;

namespace ComicEngine.Actions.Impl.StorageContainers
{
    public class StorageContainerActions : ICreateStorageContainerAction, IGetStorageContainersAction
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

        public async Task<IEnumerable<StorageContainer>> GetStorageContainers(string subject)
        {
            // TODO: VALIDATE SUBJECT
            var storageContainers = await _storageContainersRepository.GetStorageContainers(subject);

            return storageContainers;
        }
    }
}