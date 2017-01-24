using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class OrderHistory
    {
        public string modificationDate { get; set; }

        public string state { get; set; }

        public int amount { get; set; }

        public string currencyCode { get; set; }

        public int currencyCodeExponent { get; set; }

        public int netAmount { get; set; }

        public string settlementCurrency { get; set; }

        public int settlementCurrencyExponent { get; set; }

        public int commission { get; set; }
    }
}
