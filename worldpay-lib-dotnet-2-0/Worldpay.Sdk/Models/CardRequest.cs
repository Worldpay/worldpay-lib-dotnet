namespace Worldpay.Sdk.Models
{
    public class CardRequest : AbstractCard
    {
        public string cardNumber { get; set; }

        public string cvc { get; set; }
    }
}
