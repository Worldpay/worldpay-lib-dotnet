namespace Worldpay.Sdk.Models
{
    public class CardRequest : AbstractCard
    {
        public CardRequest()
        {
            this.type = "Card";
        }

        public string cardNumber { get; set; }

        public string cvc { get; set; }
    }
}
