using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class OrderHistory
    {
        [DataMember]
        public string modificationDate { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember]
        public int amount { get; set; }

        [DataMember]
        public string currencyCode { get; set; }

        [DataMember]
        public int currencyCodeExponent { get; set; }

        [DataMember]
        public int netAmount { get; set; }

        [DataMember]
        public string settlementCurrency { get; set; }

        [DataMember]
        public int settlementCurrencyExponent { get; set; }

        [DataMember]
        public int commission { get; set; }
    }
}
