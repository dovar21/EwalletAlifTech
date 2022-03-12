using EwalletAlifTech.Modules.DigestAuthentication.Implementation;
using Microsoft.AspNetCore.Authentication;

namespace EwalletAlifTech.Modules.DigestAuthentication.Options
{
    internal class DigestAuthenticationOptions : AuthenticationSchemeOptions
    {
        public DigestAuthenticationConfiguration Configuration;
    }
}