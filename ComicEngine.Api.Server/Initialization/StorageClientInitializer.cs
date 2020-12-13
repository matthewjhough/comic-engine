using ComicEngine.Api.Server.Actions.StorageContainers;
using ComicEngine.Api.Server.StorageContainers;
using ComicEngine.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComicEngine.Api.Server.Initialization
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