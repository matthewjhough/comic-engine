using ComicEngine.Api.UserComics;
using ComicEngine.Common;
using ComicEngine.Data.MongoDb.UserComics;
using ComicEngine.Data.MsSql.UserComics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ComicEngine.Api.Initialization
{
    public class UserComicsInit : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<UserComicsDatabaseSettings>(configuration
                    .GetSection(nameof(UserComicsDatabaseSettings)))
                .AddSingleton<IUserComicsDatabaseSettings>(sp =>
                    sp.GetRequiredService<IOptions<UserComicsDatabaseSettings>>()
                        .Value);
            services
                .AddSingleton(sp => new UserComicContext(configuration))
                .AddSingleton<IUserComicsRepository, UserComicsRepository>(sp =>
                    new UserComicsRepositoryBuilder()
                        .WithLogger(
                            sp.GetRequiredService<ILogger<UserComicsRepository>>())
                        .WithStorageClient(
                            new MongoDbUserComicStorageClientBuilder()
                                .WithDatabaseSettings(
                                    sp.GetRequiredService<IUserComicsDatabaseSettings>())
                                .Build())
                        .Build());
        }
    }
}