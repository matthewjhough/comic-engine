using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComicEngine.Shared
{
    public interface IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration);
    }
}