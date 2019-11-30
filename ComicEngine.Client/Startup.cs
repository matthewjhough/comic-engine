using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComicEngineClient {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // In production, the React files will be served from this directory
            services.AddControllers ();
            services.AddAuthorization ();
            services.AddRazorPages ();
            services.AddSpaStaticFiles (configuration => {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Error");
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseSpaStaticFiles ();

            // Runs matching. An endpoint is selected and set on the HttpContext if a match is found.
            app.UseRouting ();

            // begin Auth middleware
            app.UseAuthentication ();
            app.UseAuthorization ();
            app.UseCors ();
            // end Auth middleware

            // Executes the endpoint that was selected by routing.
            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
                endpoints.MapRazorPages ();
            });

            app.UseSpa (spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment ()) {
                    spa.UseReactDevelopmentServer (npmScript: "start");
                }
            });
        }
    }
}