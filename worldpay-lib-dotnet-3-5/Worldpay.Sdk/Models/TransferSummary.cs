using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class TransferSummary
    {
        [DataMember]
        public int netAmount { get; set; }

        [DataMember]
        public string settlementCurrency { get; set; }

        [DataMember]
        public string settlementCurrencyExponent { get; set; }

        [DataMember]
        public string bankName { get; set; }

        [DataMember]
        public string transferDate { get; set; }

        [DataMember]
        public string transferId { get; set; }

        [DataMember]
        public string batchId { get; set; }
    }
}
