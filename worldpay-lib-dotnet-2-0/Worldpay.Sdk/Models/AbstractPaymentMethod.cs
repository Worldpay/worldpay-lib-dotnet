namespace Worldpay.Sdk.Models
{
    abstract public class AbstractPaymentMethod
    {
        public string type { get; set; }

        public string name { get; set; }

        public Address address { get; set; }
    }
}
