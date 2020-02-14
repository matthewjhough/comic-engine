using ComicEngine.Client.IdentityServer;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ComicEngine.Client.Data {
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser> {
        public ApplicationDbContext (
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base (options, operationalStoreOptions) { }
    }
}