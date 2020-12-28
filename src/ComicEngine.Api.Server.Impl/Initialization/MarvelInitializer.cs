using ComicEngine.Actions.Marvel;
using ComicEngine.Actions.Search.Impl;
using ComicEngine.Actions.Search.Impl.Marvel;
using ComicEngine.Api.Server.Impl.Marvel;
using ComicEngine.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Impl.Initialization
{
    public class MarvelInitializer : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<IGetMarvelAction, MarvelActions>()
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