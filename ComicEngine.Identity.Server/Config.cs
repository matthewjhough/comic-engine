// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace ComicEngine.Identity.Server
{
    public static class Config
    {
        private static readonly string ExampleSecret = "511536EF-F270-4058-80CA-1C89C192F69A";

        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
            new[]
            {
                new ApiResource("comicapi")
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "comic_api",
                    ClientName = "Comic Engine Api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret(ExampleSecret.Sha256())},
                    AllowedScopes = { "comicapi" }
                },

                // MVC client using code flow + pkce
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequirePkce = true,
                    ClientSecrets = {new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256())},

                    RedirectUris = {"http://localhost:5003/signin-oidc"},
                    FrontChannelLogoutUri = "http://localhost:5003/signout-oidc",
                    PostLogoutRedirectUris = {"http://localhost:5003/signout-callback-oidc"},

                    AllowOfflineAccess = true,
                    AllowedScopes = {"openid", "profile", "api1"}
                },

                // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "ComicEngine.Graphql",
                    ClientName = "ComicEngine Graphql",
                    ClientUri = "http://localhost:5002",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = false,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "http://localhost:5002",
                        "http://localhost:5002/index.html",
                        "http://localhost:5002/callback.html",
                        "http://localhost:5002/silent.html",
                        "http://localhost:5002/popup.html",
                    },

                    PostLogoutRedirectUris = {"http://localhost:5002/index.html"},
                    AllowedCorsOrigins = {"http://localhost:5002"},

                    AllowedScopes = {"openid", "profile", "comic_api"}
                }
            };
    }
}