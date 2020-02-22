using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ComicEngine.Api {
    public class Program {
        public static void Main (string[] args) {
            CreateHostBuilder (args).Build ().Run ();
        }

        public static IWebHostBuilder CreateHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseUrls ("https://0.0.0.0:6001", "http://0.0.0.0:6002")
            .UseStartup<Startup> ();
    }
}