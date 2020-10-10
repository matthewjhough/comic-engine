using ComicEngine.Api.Commands.Marvel;
using ComicEngine.Api.Commands.UserComic;
using ComicEngine.Api.Marvel;
using ComicEngine.Api.UserComics;
using ComicEngine.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComicEngine.Api.Initialization
{
    public class CommandInit : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<IGetMarvelCommand, MarvelCommands>()
                .AddSingleton<IGetUserComicCommand, UserComicCommands>()
                .AddSingleton<ICreateUserComicCommand, UserComicCommands>();
        }
    }
}