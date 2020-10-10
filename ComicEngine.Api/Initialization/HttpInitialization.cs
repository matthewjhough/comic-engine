using ComicEngine.Api.Marvel;
using ComicEngine.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Initialization
{
    public class HttpInitialization : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddHttpClient ()
                .AddSingleton(sp =>
                    new MarvelHttpClient (
                        sp.GetRequiredService<ILogger<MarvelHttpClient>> (),
                        configuration
                            .GetSection ("marvelApi")
                            .Get<MarvelApiConfig> (),
                        sp.GetRequiredService<IHttpContextAccessor>()
                    ))
                .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                .AddCors(options =>
                {
                    // this defines a CORS policy called "default"
                    options.AddPolicy("default", policy =>
                    {
                        policy.WithOrigins("https://localhost:5003")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });
        }
    }
}