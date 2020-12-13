using ComicEngine.Api.Actions.Marvels;
using ComicEngine.Api.Marvel;
using ComicEngine.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Initialization
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