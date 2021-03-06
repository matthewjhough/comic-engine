using System;
using ComicEngine.Api.Client;
using ComicEngine.Api.Client.Comics;
using ComicEngine.Api.Client.Impl.Comics;
using ComicEngine.Api.Client.Impl.StorageContainers;
using ComicEngine.Api.Client.Impl.UserComics;
using ComicEngine.Api.Client.StorageContainers;
using ComicEngine.Api.Client.UserComics;
using ComicEngine.Graphql.Server.Impl.Types;
using ComicEngine.Identity.Client.Impl;
using ComicEngine.Shared;
using HotChocolate;
using HotChocolate.AspNetCore;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Server.Impl {
    public class Startup
    {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger(nameof(Startup));

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            ApplicationLogging.LoggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }

        private string DevelopmentCors = "DevelopmentCors";

        public void ConfigureServices(IServiceCollection services)
        {
            #region cors

            // todo: add appsettings flag for isDevelopment to enable this
            services.AddCors(options => options.AddPolicy(DevelopmentCors,
                corsBuilder =>
                {
                    corsBuilder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));

            var cors = new DefaultCorsPolicyService(
                ApplicationLogging.LoggerFactory.CreateLogger<DefaultCorsPolicyService>()
            )
            {
                AllowAll = true
            };

            services.AddSingleton<ICorsPolicyService>(cors);

            #endregion cors
            var tokenClientSettings = Configuration
                .GetSection("TokenClient")
                .Get<TokenClientSettings>();
            
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, 
                    options =>
                    {
                        options.Authority = tokenClientSettings.Authority;
                        
                        options.RequireHttpsMetadata = true;
                    });

            var comicEngineApiClientConfig = Configuration
                .GetSection("ComicEngineApiConfiguration")
                .Get<ComicEngineApiConfiguration>();
            
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>()
                .AddSingleton<IComicHttpRepository, ComicHttpRepository>(sp =>
                    new ComicHttpRepository(
                        comicEngineApiClientConfig,
                        sp.GetRequiredService<IHttpContextAccessor>(),
                        tokenClientSettings))
                .AddSingleton<IUserComicsHttpRepository, UserComicsHttpRepository>(sp =>
                    new UserComicsHttpRepository(
                        comicEngineApiClientConfig, 
                        sp.GetRequiredService<IHttpContextAccessor>(),
                        tokenClientSettings))
                .AddSingleton<IStorageContainerHttpRepository, StorageContainerHttpRepository>(sp =>
                    new StorageContainerHttpRepository(
                        comicEngineApiClientConfig,
                        sp.GetRequiredService<IHttpContextAccessor>(),
                        tokenClientSettings));

            services.AddControllersWithViews();
            services.AddRazorPages();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            // Add dotnet HttpClient
            services.AddHttpClient();
            services.AddGraphQL(sp =>
                SchemaBuilder.New()
                    .AddServices(sp)
                    .AddQueryType<QueryType>()
                    .AddMutationType<MutationType>()
                    // Move this out to reusable middleware for error reporting
                    .Use(next => async context =>
                    {
                        Logger.LogDebug("Context info: {contextInfo}", context.Variables);
                        await next(context);
                    })
                    .Create());

            services.AddErrorFilter(error =>
            {
                Logger.LogDebug("Error received... {err}", error.Exception?.Message);
                Logger.LogDebug("Error message: {msg}", error.Message);
                if (error.Exception is NullReferenceException)
                {
                    return error.WithCode("NullRef");
                }

                return error;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // TODO: Add Appsettings flag to enable/disable this.
            app.UseCors(DevelopmentCors);
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // todo: enable authorization
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            app.UseGraphQL("/graphql");
            // todo: Add Appsettings flag to enable/disable this.
            app.UsePlayground();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}