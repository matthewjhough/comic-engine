using System;
using System.Threading.Tasks;
using ComicEngine.Api.Server.Actions.StorageContainers;
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
        private readonly ILogger _logger;

        public StorageContainerV1Controller (
            ICreateStorageContainerAction createStorageContainerAction,
            ILogger<StorageContainerV1Controller> logger
        ) {
            _createStorageContainerAction = createStorageContainerAction;
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
    }
}