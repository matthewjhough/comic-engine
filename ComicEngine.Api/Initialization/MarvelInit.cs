using ComicEngine.Api.Commands.Marvels;
using ComicEngine.Api.Commands.UserComics;
using ComicEngine.Api.Marvel;
using ComicEngine.Api.UserComics;
using ComicEngine.Api.UserComics.CreateUserComic;
using ComicEngine.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Initialization
{
    public class MarvelInit : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<IGetMarvelCommand, MarvelCommands>()
                .AddSingleton(sp =>
                    new MarvelHttpClient (
                        sp.GetRequiredService<ILogger<MarvelHttpClient>> (),
                        configuration
                            .GetSection ("marvelApi")
                            .Get<MarvelApiConfig> (),
                        sp.GetRequiredService<IHttpContextAccessor>()
                    ));
        }
    }
}