using ComicEngine.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ComicEngine.Api.Initialization
{
    public class AuthInit : IStartupInitialization
    {
        public void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, 
                    options =>
                    {
                        var tokenClientConfig = configuration
                            .GetSection("TokenClient");
                        // TODO: Get from appsettings.
                        options.Authority = tokenClientConfig
                                .GetSection("Authority")
                                .Get<string>()
                            ;
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };
                        options.Audience = "foo";
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "comic.api");
                });
            });
        }
    }
}