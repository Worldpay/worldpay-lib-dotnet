namespace Worldpay.Sdk.Models
{
    public class TokenRequest : AbstractTokenRequest
    {
        public AbstractPaymentMethod paymentMethod { get; set; }

        public bool reusable { get; set; }
    }
}
