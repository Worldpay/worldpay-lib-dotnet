namespace Worldpay.Sdk.Models
{
    abstract public class AbstractCard : AbstractPaymentMethod
    {
        public string name { get; set; }

        public int expiryMonth { get; set; }

        public int expiryYear { get; set; }

        public int? issueNumber { get; set; }

        public int? startMonth { get; set; }

        public int? startYear { get; set; }
    }
}
