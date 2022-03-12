using EwalletAlifTech.Modules.DigestAuthentication.Implementation;
using EwalletAlifTech.Modules.DigestAuthentication.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.DigestAuthentication.Handlers
{
    internal class DigestAuthenticationHandler : AuthenticationHandler<DigestAuthenticationOptions>
    {
        private readonly IUsernameHashedSecretProvider _usernameHashedSecretProvider;

        private DigestAuthImplementation _digestAuth;

        public DigestAuthenticationHandler(IOptionsMonitor<DigestAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock) {
        }

        public DigestAuthenticationHandler(IOptionsMonitor<DigestAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUsernameHashedSecretProvider usernameHashedSecretProvider)
            : base(options, logger, encoder, clock)
        {
            _usernameHashedSecretProvider = usernameHashedSecretProvider;
        }

        protected override async Task InitializeHandlerAsync() {
            await base.InitializeHandlerAsync();

            var clock = new SystemClockProxy(Clock);

            if (_usernameHashedSecretProvider != null) {
                _digestAuth = new DigestAuthImplementation(Options.Configuration, _usernameHashedSecretProvider, clock);
            } 
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
            if (!Request.Headers.TryGetValue(DigestAuthImplementation.AuthorizationHeaderName, out var headerValue)) {
                return AuthenticateResult.NoResult();
            }

            if (!DigestChallengeResponse.TryParse(headerValue, out var challengeResponse)) {
                return AuthenticateResult.NoResult();
            }

            string validatedUsername = await _digestAuth.ValidateChallangeAsync(challengeResponse, Request.Method);

            if (validatedUsername == null) {
                return AuthenticateResult.NoResult();
            }

            var identity = new ClaimsIdentity(Scheme.Name);
            identity.AddClaim(new Claim(DigestAuthImplementation.DigestAuthenticationClaimName, validatedUsername));
            var principal = new ClaimsPrincipal(identity);

            if (_digestAuth.UseAuthenticationInfoHeader) {
                Response.Headers[DigestAuthImplementation.AuthenticationInfoHeaderName] = await _digestAuth.BuildAuthInfoHeaderAsync(challengeResponse);
            }

            return AuthenticateResult.Success(new AuthenticationTicket(principal, new AuthenticationProperties(), Scheme.Name));
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties) {
            await base.HandleChallengeAsync(properties);

            if (Response.StatusCode == (int) HttpStatusCode.Unauthorized) {
                Response.Headers[DigestAuthImplementation.AuthenticateHeaderName] = _digestAuth.BuildChallengeHeader();
            }
        }
    }

    internal class SystemClockProxy : IClock
    {
        private readonly ISystemClock _systemClock;

        public SystemClockProxy(ISystemClock systemClock) {
            _systemClock = systemClock;
        }

        public DateTime UtcNow => _systemClock.UtcNow.UtcDateTime;
    }
}