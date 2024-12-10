using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Microsoft.Identity.Client;

namespace Microsoft.Mso.ContentPackModules.Tenant
{
    public class Option2
    {
        private readonly List<string> _scopes = new List<string>()
        {
            "https://graph.microsoft.com/.default"
        };

        private async Task<string> GetGraphAuthTokenAsync(string tenantId)
        {
            var authorityUrl = $"https://login.microsoftonline.com/{tenantId}/v2.0";

            var confidentialClient = ConfidentialClientApplicationBuilder.Create("YOUR_ENTRA_APP_CLIENT_ID")
                .WithAuthority(new Uri(authorityUrl))
                .WithClientAssertion(async (AssertionRequestOptions options) => await GetClientAssertionAsync(authorityUrl))
                .Build();

            var result = await confidentialClient.AcquireTokenForClient(_scopes.ToArray()).ExecuteAsync();
            return result.AccessToken;
        }

        private async Task<string> GetClientAssertionAsync(string authorityUrl)
        {
            var federatedCredentialAudience = new[] { "api://AzureADTokenExchange/.default" };
            var options =
                new ManagedIdentityCredentialOptions(
                    ManagedIdentityId.FromUserAssignedClientId("YOUR_USER_ASSIGNED_IDENTITY_CLIENT_ID"));
            if (authorityUrl != null)
            {
                options.AuthorityHost = new Uri(authorityUrl);
            }
            var credential = new ManagedIdentityCredential(options);
            var context = new TokenRequestContext(federatedCredentialAudience);
            var token = await credential.GetTokenAsync(context, CancellationToken.None);
            return token.Token;
        }
    }
}
