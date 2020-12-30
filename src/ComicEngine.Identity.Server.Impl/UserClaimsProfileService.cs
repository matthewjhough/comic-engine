using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComicEngine.Identity.Server.Impl
{
    public class UserClaimsProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // Include configured claims.
            context.AddRequestedClaims(context.Subject.Claims);

            // The service gets called multiple times. In this case we need
            // the UserInfo endpoint because that's where the scope is defined.
            if (context.Caller == "UserInfoEndpoint")
            {
                // Get the value from somewhere and transform to a list of claims.
                // You can filter by requested scopes
                List<Claim> userClaims = GetUserClaims(context.RequestedResources.IdentityResources);
            
                if (userClaims.Any())
                    context.IssuedClaims.AddRange(userClaims);
            }
        }

        public List<Claim> GetUserClaims(ICollection<IdentityResource> collection)
        {
            return new List<Claim>();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}