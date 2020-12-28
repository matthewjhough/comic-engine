using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ComicEngine.Api.Server.Impl {
    public class Program {
        public static void Main (string[] args) {
            CreateHostBuilder (args).Build ().Run ();
        }

        public static IWebHostBuilder CreateHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseUrls ("http://0.0.0.0:6002") // "https://0.0.0.0:6001", 
            .UseStartup<Startup> ();
    }
}