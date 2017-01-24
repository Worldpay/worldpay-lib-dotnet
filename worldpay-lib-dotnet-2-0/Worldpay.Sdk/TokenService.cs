using System;
using Worldpay.Sdk;
using Worldpay.Sdk.Models;

namespace WorldPay.Sdk
{
    public class TokenService : AbstractService
    {
        private readonly string _baseUrl;

        public TokenService(String baseUrl, Http http)
            : base(http)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Retrieve stored card details
        /// </summary>
        /// <param name="token">The token of the card to obtain details for</param>
        /// <returns>The obfuscated card details associated with the token provided</returns>
        public TokenResponse Get(string token)
        {
            return Http.Get<TokenResponse>(String.Format("{0}/tokens/{1}", _baseUrl, token));
        }
    }
}
