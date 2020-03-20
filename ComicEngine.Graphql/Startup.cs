using System.Net.Http;
using ComicEngine.Graphql.ComicEngineApi;
using ComicEngine.Graphql.Graphql;
using ComicEngine.Graphql.IdentityServer;
using ComicEngine.Graphql.IdentityServer.Data;
using HotChocolate;
using HotChocolate.AspNetCore;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql {
    public class Startup {
        private ILoggerFactory _loggerFactory;

        public Startup (IConfiguration configuration, ILoggerFactory loggerFactory) {
            Configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }

        private string DevelopmentCors = "DevelopmentCors";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext> (options =>
                options.UseSqlite (
                    Configuration.GetConnectionString ("DefaultConnection")));

            #region cors
            // todo: add appsettings flag for isDevelopment to enable this
            services.AddCors (options => options.AddPolicy (DevelopmentCors,
                builder => {
                    builder.AllowAnyOrigin ()
                        .AllowAnyMethod ()
                        .AllowAnyHeader ();
                }));

            var cors = new DefaultCorsPolicyService (
                _loggerFactory.CreateLogger<DefaultCorsPolicyService> ()
            ) {
                AllowAll = true
            };

            services.AddSingleton<ICorsPolicyService> (cors);

            #endregion cors

            services.AddSingleton<IComicHttpClient> (sp =>
                new ComicHttpClient (
                    sp.GetRequiredService<ILogger<IComicHttpClient>> (),
                    sp.GetRequiredService<IHttpClientFactory> (),
                    Configuration
                    .GetSection ("ComicHttpClientConfig")
                    .Get<ComicHttpClientConfig> ()
                ));

            services.AddSingleton<IComicEngineApiService, ComicEngineApiService> ();

            services.AddDefaultIdentity<ApplicationUser> ()
                .AddEntityFrameworkStores<ApplicationDbContext> ();

            services.AddIdentityServer ()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext> ();

            services.AddAuthentication ()
                .AddIdentityServerJwt ();

            services.AddControllersWithViews ();
            services.AddRazorPages ();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles (configuration => {
                configuration.RootPath = "ClientApp/build";
            });

            // Add dotnet HttpClient
            services.AddHttpClient ();

            services.AddGraphQL (services =>
                SchemaBuilder.New ()
                .AddServices (services)
                .AddQueryType<Query> ()
                .AddMutationType<Mutation> ()
                .Create ());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            } else {
                app.UseExceptionHandler ("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            // todo: Add Appsettings flag to enable/disable this.
            app.UseCors (DevelopmentCors);

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseSpaStaticFiles ();

            app.UseRouting ();

            app.UseAuthentication ();
            app.UseIdentityServer ();
            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages ();
            });

            app.UseGraphQL ("/graphql");
            // todo: Add Appsettings flag to enable/disable this.
            app.UsePlayground ();

            app.UseSpa (spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment ()) {
                    spa.UseReactDevelopmentServer (npmScript: "start");
                }
            });
        }
    }
}