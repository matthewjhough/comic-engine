using ComicEngine.Api.Comics;
using ComicEngine.Api.Commands.Marvel;
using ComicEngine.Api.Commands.SavedComic;
using ComicEngine.Api.Marvel;
using ComicEngine.Data.MsSql.Comics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ComicEngine.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, 
                    options =>
                {
                    var tokenClientConfig = Configuration
                        .GetSection("TokenClient");
                    // TODO: Get from appsettings.
                    options.Authority = tokenClientConfig
                            .GetSection("Authority")
                            .Get<string>()
                        ;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                    options.Audience = "foo";
                })
                ;

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "comic.api");
                });
            });
            
            services.AddHttpClient ();
            services.AddSingleton(sp =>
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
            
            services.AddCors(options =>
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
            
            app.UseAuthentication ();
            app.UseHttpsRedirection ();
            app.UseRouting ();
            app.UseAuthorization ();
            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ().RequireAuthorization();
            });
        }
    }
}