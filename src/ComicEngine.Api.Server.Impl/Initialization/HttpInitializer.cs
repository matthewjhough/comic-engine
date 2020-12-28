using ComicEngine.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server.Impl.Initialization
{
    public class HttpInitializer : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddHttpClient ()
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