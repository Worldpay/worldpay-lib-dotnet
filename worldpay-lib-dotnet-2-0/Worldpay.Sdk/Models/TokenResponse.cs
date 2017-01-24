namespace Worldpay.Sdk.Models
{
    public class TokenResponse
    {
        public string token { get; set; }

        public PaymentResponse paymentMethod { get; set; }

        public bool reusable { get; set; }
    }
}
