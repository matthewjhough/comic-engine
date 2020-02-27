using ComicEngine.Api.Marvel;
using ComicEngine.Api.Marvel.Commands;
using ComicEngine.Api.Marvel.HttpClient;
using ComicEngine.Api.SavedComics;
using ComicEngine.Api.SavedComics.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api {
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
                .AddSingleton<ICreateSavedComicCommand, SavedComicCommands> ()
                .AddSingleton<SavedComicContext> (sp =>
                    new SavedComicContext (Configuration))
                .AddSingleton<ISavedComicsRepository, SavedComicsRepository> (sp =>
                    new SavedComicsRepository (Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory> ().CreateScope ()) {
                var context = serviceScope.ServiceProvider.GetRequiredService<SavedComicContext> ();
                context.Database.EnsureCreated ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}