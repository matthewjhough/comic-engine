using System.Threading.Tasks;
using ComicEngine.Identity.Client;
using ComicEngine.Shared;
using ComicEngine.Shared.StorageContainers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client
{
    public class StorageContainerHttpRepository : IStorageContainerHttpRepository
    {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (StorageContainerHttpRepository));
        private readonly ComicEngineApiRepositoryConfiguration _comicApiRepositoryConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenClientSettings _tokenClientSettings;

        /// <summary>
        /// Repository for interacting with <see cref="StorageContainer"/> within the Comic Engine Comic API
        /// </summary>
        /// <param name="config"><see cref="StorageContainerHttpRepository"/> pulled from the appsettings.</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="tokenClientSettings"></param>
        public StorageContainerHttpRepository (
            ComicEngineApiRepositoryConfiguration config, 
            IHttpContextAccessor httpContextAccessor, 
            TokenClientSettings tokenClientSettings) {
            _comicApiRepositoryConfig = config;
            _httpContextAccessor = httpContextAccessor;
            _tokenClientSettings = tokenClientSettings;
        }
        
        public Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer, string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}