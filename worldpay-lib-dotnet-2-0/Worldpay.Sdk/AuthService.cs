using Worldpay.Sdk;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    /// <summary>
    /// Class for interacting with the Worldpay authorization API
    /// </summary>
    public class AuthService : AbstractService
    {
        public AuthService(Http http) : base(http) { }

        /// <summary>
        /// Get a temporary access token
        /// </summary>
        public TokenResponse GetToken(TokenRequest tokenRequest)
        {
            var tokenResponse = Http.Post<TokenRequest, TokenResponse>(Configuration.TokenUrl, tokenRequest);
            return tokenResponse;
        }
    }
}
