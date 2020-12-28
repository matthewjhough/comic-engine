using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComicEngine.Actions.StorageContainers;
using ComicEngine.Shared;
using ComicEngine.Shared.StorageContainers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.StorageContainers
{
    [ApiController]
    [Authorize]
    public class StorageContainerV1Controller : Controller
    {
        private readonly ICreateStorageContainerAction _createStorageContainerAction;
        private readonly IGetStorageContainersAction _getStorageContainersAction;
        private readonly ILogger _logger;

        public StorageContainerV1Controller (
            ICreateStorageContainerAction createStorageContainerAction,
            IGetStorageContainersAction getStorageContainersAction,
            ILogger<StorageContainerV1Controller> logger
        ) {
            _createStorageContainerAction = createStorageContainerAction;
            _getStorageContainersAction = getStorageContainersAction;
            _logger = logger;
        }
        
        [HttpPost (EndpointsV1.StorageContainerEndpointBase)]
        public async Task<StorageContainer> Create ([FromBody] StorageContainer storageContainer) {
            // TODO: Validation
            if (storageContainer is null) {
                throw new Exception ("Storage container is required.");
            }
            
            _logger.LogDebug ("**** Storage container from body label: {label} ****", storageContainer.Label);
            
            var userComic = await _createStorageContainerAction
                .CreateStorageContainer(storageContainer);
            
            return userComic;
        }
        
        [HttpGet (EndpointsV1.StorageContainerSavedEndpoint)]
        public async Task<IEnumerable<StorageContainer>> Get ([FromRoute] string userId)
        {
            _logger.LogDebug("Retrieving storage containers for user '{userId}'", userId);
            
            // Todo: add logging / exception handling
            var storageContainers = await _getStorageContainersAction
                .GetStorageContainers(userId);
            
            var containers = storageContainers
                .ToList();
            
            _logger.LogDebug(
                "Found '{storageContainerCount}' storage containers '{userId}'", 
                containers.Count, 
                userId);
            
            return containers;
        }
    }
}