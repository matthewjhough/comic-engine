using ComicEngine.Api.Commands.Marvel;
using ComicEngine.Api.Commands.SavedComic;
using ComicEngine.Api.Server.Comics;
using ComicEngine.Api.Server.Marvel;
using ComicEngine.Data.MsSql.Comics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Api.Server {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
            services.AddHttpClient ();
            services.AddSingleton<MarvelHttpClient> (sp =>
                    new MarvelHttpClient (
                        sp.GetRequiredService<ILogger<MarvelHttpClient>> (),
                        Configuration
                            .GetSection ("marvelApi")
                            .Get<MarvelApiConfig> (),
                        sp.GetRequiredService<IHttpContextAccessor>()
                    ))
                .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                .AddSingleton<IGetMarvelCommand, MarvelCommands> ()
                .AddSingleton<IGetSavedComicCommand, ComicCommands> ()
                .AddSingleton<ILoggerFactory, LoggerFactory> ()
                .AddSingleton<ICreateSavedComicCommand, ComicCommands> ()
                .AddSingleton(sp =>
                    new ComicContext (Configuration))
                .AddSingleton<IComicsRepository, ComicsRepository> (sp =>
                    new ComicsRepositoryBuilder()
                        .WithLogger(
                            sp.GetRequiredService<ILogger<ComicsRepository>>())
                        .WithStorageClient(
                            new EntityComicStorageClientBuilder()
                                .WithComicContext(
                                    sp.GetRequiredService<ComicContext>())
                                .Build())
                        .Build());
            
            // TODO: Setup correctly when access tokens enabled
            services.AddAuthentication("Bearer");
            services.AddAuthentication ("Bearer")
                .AddJwtBearer ("Bearer", options =>
                {
                    options.ClaimsIssuer = "http://localhost:5002";
                    options.Authority = "http://localhost:5002";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "comic_api";
                    options.IncludeErrorDetails = true;
                })
                ;
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