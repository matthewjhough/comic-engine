using ComicEngine.Api.Commands.Marvel;
using ComicEngine.Api.Commands.SavedComics;
using ComicEngine.Api.Server.Marvel;
using ComicEngine.Api.Server.SavedComics;
using ComicEngine.Data.MsSql.Comics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
            services.AddHttpClient ();
            services.AddSingleton<MarvelHttpClient> (sp =>
                    new MarvelHttpClient (
                        sp.GetRequiredService<ILogger<MarvelHttpClient>> (),
                        Configuration.GetSection ("marvelApi").Get<MarvelApiConfig> ()
                    ))
                .AddSingleton<IGetMarvelCommand, MarvelCommands> ()
                .AddSingleton<IGetSavedComicCommand, SavedComicCommands> ()
                .AddSingleton<ILoggerFactory, LoggerFactory> ()
                .AddSingleton<ICreateSavedComicCommand, SavedComicCommands> ()
                .AddSingleton<ComicContext> (sp =>
                    new ComicContext (Configuration))
                .AddSingleton<ISavedComicsRepository, SavedComicsRepository> (sp =>
                    new SavedComicsRepository (Configuration));

            services.AddAuthentication ("Bearer")
                .AddJwtBearer ("Bearer", options => {
                    options.Authority = "http://localhost:5002";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "comicapi";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory> ()
                .CreateScope ()) {
                var context = serviceScope.ServiceProvider
                    .GetRequiredService<ComicContext> ();
                context
                    .Database
                    .EnsureCreated ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();
            app.UseAuthentication ();
            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}