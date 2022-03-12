using EwalletAlifTech.Modules.Core.Exceptions;
using EwalletAlifTech.Modules.DigestAuthentication.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EwalletAlifTech.Modules.Core.Controllers
{
    /// <summary>
    /// Base controller class
    /// </summary>
    [Authorize(AuthenticationSchemes = "Digest")]
    public abstract class AuthorizeControllerBase : ControllerBase
    {
        /// <summary>
        /// Get authorized user
        /// </summary>
        /// <returns>Username</returns>
        public string GetAuthorizedUsername()
        {
            if (!Request.Headers.TryGetValue(DigestAuthImplementation.AuthorizationHeaderName, out var headerValue))
                throw new AccessForbiddenException();

            if (!DigestChallengeResponse.TryParse(headerValue, out var challengeResponse))
                throw new AccessForbiddenException();

            return challengeResponse.Username;
        }
    }
}
