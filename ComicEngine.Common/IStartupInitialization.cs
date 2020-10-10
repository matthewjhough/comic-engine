using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComicEngine.Common
{
    public interface IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration);
    }
}