using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using ComicEngine.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ComicEngine.Graphql.Server.Types
{
    /// <summary>
    /// Support Class for handling common <see cref="Authorization"/> operations.
    /// </summary>
    public static class IdentityTokenSupport
    {
        private static readonly ILogger Logger = ApplicationLogging.CreateLogger (nameof (QueryType));

        /// <summary>
        /// Accepts the <see cref="HttpContext"/>, and returns the token from the
        /// <see cref="Authorization"/> <see cref="HttpContext.Request.Headers"/> property.
        /// </summary>
        /// <param name="httpContext">The <see cref="HttpContext"/> From <see cref="HttpRequest"/></param>
        /// <returns><see cref="string"/> Id_Token.</returns>
        public static string ResolveIdentityToken(HttpContext httpContext)
        {
            try
            {
                var requestToken = httpContext?.Request.Headers["Authorization"]
                    .ToString()
                    .Split(" ")
                    [1];
                    
                return requestToken;
            }
            catch (Exception e)
            {
                Logger.LogDebug("Unable to resolve token from Authorization Header of request.");
                throw;
            }

        }

        /// <summary>
        /// Accepts an Id_Token, and returns the subject id associated with it.
        /// </summary>
        /// <param name="token">The <see cref="JwtSecurityToken"/> from the current user.</param>
        /// <returns><see cref="string"/> with the subject id.</returns>
        public static string GetTokenSubject(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadToken(token) as JwtSecurityToken;
            return jwt?.Claims.First(claim => claim.Type == "sub").Value;
        }
    }
}