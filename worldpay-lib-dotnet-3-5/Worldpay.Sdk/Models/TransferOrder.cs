using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Json;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class TransferOrder
    {
        [DataMember]
        public int netAmount { get; set; }

        [DataMember]
        public int commission { get; set; }

        [DataMember]
        public string settlementCurrency { get; set; }

        [DataMember]
        public int settlementCurrencyExponent { get; set; }

        [DataMember]
        public int chargedbackAmount { get; set; }

        [DataMember]
        public int currencyCodeExponent { get; set; }

        [DataMember]
        public DateTime creationDate { get; set; }

        [DataMember]
        public string modificationDate { get; set; }

        [DataMember]
        public List<OrderHistory> history { get; set; }

        [DataMember]
        public string environment { get; set; }

        [DataMember]
        public string paymentStatus { get; set; }

        [DataMember]
        public string orderCode { get; set; }

        [DataMember]
        public string customerOrderCode { get; set; }

        [DataMember]
        public PaymentResponse paymentResponse { get; set; }

        [DataMember]
        public List<Warning> warnings { get; set; }

        [DataMember, JsonConverter(typeof(EntryConverter))]
        public List<Entry> customerIdentifiers { get; set; }

        [DataMember]
        public string paymentStatusReason { get; set; }

        [DataMember]
        public CurrencyCode currencyCode { get; set; }

        [DataMember]
        public string token { get; set; }

        [DataMember]
        public string orderDescription { get; set; }

        [DataMember]
        public int amount { get; set; } 
    }
}
