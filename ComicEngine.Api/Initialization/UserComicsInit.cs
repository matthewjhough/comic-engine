using ComicEngine.Api.Actions.UserComics;
using ComicEngine.Api.UserComics;
using ComicEngine.Api.UserComics.CreateUserComic;
using ComicEngine.Data.MongoDb.UserComics;
using ComicEngine.Data.UserComics;
using ComicEngine.Shared;
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
                    .GetSection(nameof(UserComicsDatabaseSettings)));
            services.AddSingleton<IUserComicsDatabaseSettings>(sp =>
                    sp.GetRequiredService<IOptions<UserComicsDatabaseSettings>>()
                        .Value);
            services
                .AddSingleton<IUserComicsRepository, UserComicsRepository>(sp =>
                    new UserComicsRepositoryBuilder()
                        .WithLogger(
                            sp.GetRequiredService<ILogger<UserComicsRepository>>())
                        .WithStorageClient(
                            new MongoDbUserComicStorageClientBuilder()
                                .WithDatabaseSettings(
                                    sp.GetRequiredService<IUserComicsDatabaseSettings>())
                                .Build())
                        .Build())
                .AddSingleton<IGetUserComicAction, UserComicActions>(sp => 
                    new UserComicActions(sp.GetRequiredService<IUserComicsRepository>()))
                .AddSingleton<ICreateUserComicAction>(sp =>
                    new CreateUserComicActionBuilder()
                        .WithUserComicsRepository(sp.GetRequiredService<IUserComicsRepository>())
                        .Build())
                .AddSingleton<IDeleteUserComicAction, UserComicActions>(sp => 
                    new UserComicActions(sp.GetRequiredService<IUserComicsRepository>()));
        }
    }
}