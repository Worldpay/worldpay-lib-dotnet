namespace Worldpay.Sdk.Models
{
    public class AbstractOrder
    {
        public string token { get; set; }

        public string orderDescription { get; set; }

        public int? amount { get; set; }

        public string currencyCode { get; set; }

        public string settlementCurrency { get; set; }

        public bool authorizeOnly { get; set; }

        public int? authorizedAmount { get; set; }
    }
}
