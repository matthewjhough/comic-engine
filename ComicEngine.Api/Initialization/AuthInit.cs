using ComicEngine.Common;
using ComicEngine.Identity.Client;
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
                            .GetSection("TokenClient")
                            .Get<TokenClientSettings>();
                        
                        options.Authority = tokenClientConfig.Authority;
                        options.Audience = tokenClientConfig.Audience;
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };
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