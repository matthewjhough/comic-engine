using ComicEngine.Api.Server.Actions.UserComics;
using ComicEngine.Api.Server.UserComics;
using ComicEngine.Api.Server.UserComics.CreateUserComic;
using ComicEngine.Data.MongoDb.UserComics;
using ComicEngine.Data.UserComics;
using ComicEngine.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ComicEngine.Api.Server.Initialization
{
    public class UserComicsInitializer : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .Configure<UserComicsDatabaseSettings>(configuration
                    .GetSection(nameof(UserComicsDatabaseSettings)));
            services.AddSingleton<IUserComicsDatabaseSettings>(sp =>
                    sp.GetRequiredService<IOptions<UserComicsDatabaseSettings>>().Value);
            services
                .AddSingleton<IUserComicsRepository, UserComicsRepository>(sp =>
                    new UserComicsRepositoryBuilder()
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