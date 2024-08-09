using IdentityServer4.Models;
using IdentityServer4;
using IdentityModel;

namespace Orders.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("OrdersWebAPI", "Web API")
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("OrdersWebAPI", "Web API", new [] {JwtClaimTypes.Name})
                {
                    Scopes = {"OrdersWebAPI"}
                }
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "orders-web-api",
                    ClientName = "Orders Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false, 
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http:// .../singin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http:// ..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http:// .../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "OrdersWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
            

    }
}
