using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("auctionApp","Auction app full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // // m2m client credentials flow client
            // new Client
            // {
            //     ClientId = "m2m.client",
            //     ClientName = "Client Credentials Client",

            //     AllowedGrantTypes = GrantTypes.ClientCredentials,
            //     ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

            //     AllowedScopes = { "scope1" }
            // },

            // interactive client using code flow + pkce
            // new Client
            // {
            //     ClientId = "interactive",
            //     ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

            //     AllowedGrantTypes = GrantTypes.Code,

            //     RedirectUris = { "https://localhost:44300/signin-oidc" },
            //     FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
            //     PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

            //     AllowOfflineAccess = true,
            //     AllowedScopes = { "openid", "profile", "scope2" }
            // },


            new Client
            {
                //Just for development purposes
                ClientId="postman",
                ClientName="Postman",
                AllowedScopes ={"auctionApp","openid", "profile"},
                RedirectUris = { "https://www.getpostman.com/oauth2/callback" },
                ClientSecrets = { new Secret("NotASecret".Sha256()) },
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword},
            }
        };
}
