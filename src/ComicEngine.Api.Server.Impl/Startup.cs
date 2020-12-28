using System.Collections.Generic;
using ComicEngine.Api.Server.Impl.Initialization;
using ComicEngine.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComicEngine.Api.Server.Impl {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        private readonly IEnumerable<IStartupInitialization> Initializers = new IStartupInitialization[]
        {
            new AuthenticationInitializer(),
            new HttpInitializer(),
            new UserComicsInitializer(),
            new MarvelInitializer(),
            new StorageClientInitializer(),
        };

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services
                .AddControllers ();
            foreach (var initializer in Initializers)
            {
                initializer.Start(services, Configuration);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
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