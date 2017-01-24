using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class TransferSummary
    {
        public int netAmount { get; set; }

        public string settlementCurrency { get; set; }

        public string settlementCurrencyExponent { get; set; }

        public string bankName { get; set; }

        public string transferDate { get; set; }

        public string transferId { get; set; }

        public string batchId { get; set; }
    }
}
