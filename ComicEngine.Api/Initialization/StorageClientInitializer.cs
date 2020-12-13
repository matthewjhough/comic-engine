using ComicEngine.Api.Actions.StorageContainers;
using ComicEngine.Api.StorageContainers;
using ComicEngine.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComicEngine.Api.Initialization
{
    public class StorageClientInitializer : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICreateStorageContainerAction>(sp =>
                new StorageContainerActions());
        }
    }
}