using System;
using System.Net.Http;
using System.Threading.Tasks;
using ComicEngine.Identity.Client;
using ComicEngine.Shared;
using ComicEngine.Shared.StorageContainers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Client.StorageContainers
{
    public class StorageContainerHttpRepository : IStorageContainerHttpRepository
    {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (StorageContainerHttpRepository));
        private readonly ComicEngineApiConfiguration _comicApiConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TokenClientSettings _tokenClientSettings;

        /// <summary>
        /// Repository for interacting with <see cref="StorageContainer"/> within the Comic Engine Comic API
        /// </summary>
        /// <param name="config"><see cref="StorageContainerHttpRepository"/> pulled from the appsettings.</param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="tokenClientSettings"></param>
        public StorageContainerHttpRepository (
            ComicEngineApiConfiguration config, 
            IHttpContextAccessor httpContextAccessor, 
            TokenClientSettings tokenClientSettings) {
            _comicApiConfig = config;
            _httpContextAccessor = httpContextAccessor;
            _tokenClientSettings = tokenClientSettings;
        }
        
        public async Task<StorageContainer> CreateStorageContainer(StorageContainer storageContainer)
        {
            var fullUrl = $"{_comicApiConfig.ClientBaseUrl}/{EndpointsV1.StorageContainerEndpointBase}";
            
            Logger.LogDebug ("Making request to: {endpoint}", fullUrl);
            
            var client = new HttpRequestClientBuilder<StorageContainer>()
                .WithAbsoluteUrl(fullUrl)
                .WithRequestBody(storageContainer)
                .WithRequestMethod(HttpMethod.Post)
                .WithHttpContextAccessor(_httpContextAccessor)
                .WithTokenClientSettings(_tokenClientSettings)
                .Build();
            
            var savedStorageContainer = await client.Send();

            if (savedStorageContainer is null)
            {
                throw new Exception("Something went wrong during save process.");
            }

            Logger.LogDebug ("Response returned: {response}", savedStorageContainer);

            return savedStorageContainer;
        }
    }
}