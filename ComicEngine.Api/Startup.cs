using ComicEngine.Api.Commands.Marvel;
using ComicEngine.Api.Commands.UserComic;
using ComicEngine.Api.Marvel;
using ComicEngine.Api.UserComics;
using ComicEngine.Data.MsSql.UserComics;
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
                .AddSingleton<IGetUserComicCommand, UserComicCommands> ()
                .AddSingleton<ILoggerFactory, LoggerFactory> ()
                .AddSingleton<ICreateUserComicCommand, UserComicCommands> ()
                .AddSingleton(sp =>
                    new UserComicContext (Configuration))
                .AddSingleton<IUserComicsRepository, UserComicsRepository> (sp =>
                    new UserComicsRepositoryBuilder()
                        .WithLogger(
                            sp.GetRequiredService<ILogger<UserComicsRepository>>())
                        .WithStorageClient(
                            new EntityUserComicStorageClientBuilder()
                                .WithComicContext(
                                    sp.GetRequiredService<UserComicContext>())
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
                    .GetRequiredService<UserComicContext> ();
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