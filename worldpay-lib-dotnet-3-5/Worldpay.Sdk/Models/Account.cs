using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    public class Account
    {
        public string bankName { get; set; }

        public string sortCode { get; set; }

        public string accountNumber { get; set; }

        public string accountHolderName { get; set; }

        public CurrencyCode settlementCurrency { get; set; }
    }
}
