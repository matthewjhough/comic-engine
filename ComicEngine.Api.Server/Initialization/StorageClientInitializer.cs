using ComicEngine.Api.Server.Actions.StorageContainers;
using ComicEngine.Api.Server.StorageContainers;
using ComicEngine.Data.MongoDb.StorageContainers;
using ComicEngine.Data.StorageContainers;
using ComicEngine.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ComicEngine.Api.Server.Initialization
{
    public class StorageClientInitializer : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<StorageContainerDatabaseSettings>(configuration
                    .GetSection(nameof(StorageContainerDatabaseSettings)));
            services.AddSingleton<IStorageContainerDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<StorageContainerDatabaseSettings>>().Value);
            services
                .AddSingleton<ICreateStorageContainerAction>(sp =>
                    new StorageContainerActions(
                        sp.GetRequiredService<IStorageContainersRepository>()))
                .AddSingleton<IStorageContainersRepository>(sp =>
                    new StorageContainersRepositoryBuilder()
                        .WithStorageClient(new MongoDbStorageContainerStorageClientBuilder()
                            .WithDatabaseSettings(
                                sp.GetRequiredService<IStorageContainerDatabaseSettings>())
                            .Build())
                        .Build());
        }
    }
}