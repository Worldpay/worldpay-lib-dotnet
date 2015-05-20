using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Test
{
    class TestHelpers
    {
        /// <summary>
        /// Test mastercard number
        /// </summary>
        const string TestMastercardNumber = "5555 5555 5555 4444";

        /// <summary>
        /// Test Cvv number
        /// </summary>
        const string TestCvv = "123";

        /// <summary>
        /// Create an access token
        /// </summary>
        internal static string CreateToken(AuthService authService)
        {
            var tokenRequest = new TokenRequest();
            tokenRequest.clientKey = Configuration.ClientKey;

            var cardRequest = new CardRequest();
            cardRequest.cardNumber = TestMastercardNumber;
            cardRequest.cvc = TestCvv;
            cardRequest.name = "csharplib client";
            cardRequest.expiryMonth = 2;
            cardRequest.expiryYear = 2018;
            cardRequest.type = "Card";

            tokenRequest.paymentMethod = cardRequest;

            TokenResponse response = authService.GetToken(tokenRequest);
            return response.token;
        }
    }
}
