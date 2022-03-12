using EwalletAlifTech.Modules.DigestAuthentication.Handlers;
using EwalletAlifTech.Modules.DigestAuthentication.Options;
using Microsoft.AspNetCore.Authentication;

namespace EwalletAlifTech.Modules.DigestAuthentication.Implementation.Extensions
{
    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddDigestAuthentication(
            this AuthenticationBuilder builder,
            DigestAuthenticationConfiguration config) => builder.AddDigestAuthentication(config, "Digest", "Digest");
        public static AuthenticationBuilder AddDigestAuthentication(
            this AuthenticationBuilder builder,
            DigestAuthenticationConfiguration config,
            string authenticationScheme,
            string displayName
        )
        {
            return builder.AddScheme<DigestAuthenticationOptions, DigestAuthenticationHandler>(
                    authenticationScheme,
                    displayName,
                    options => { options.Configuration = config; }
                );
        }
    }
}