using System;
using System.Collections.Generic;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class TransferOrder
    {
        public int netAmount { get; set; }

        public int commission { get; set; }

        public string settlementCurrency { get; set; }

        public int settlementCurrencyExponent { get; set; }

        public int chargedbackAmount { get; set; }

        public int currencyCodeExponent { get; set; }

        public DateTime creationDate { get; set; }

        public string modificationDate { get; set; }

        public List<OrderHistory> history { get; set; }

        public string environment { get; set; }

        public string paymentStatus { get; set; }

        public string orderCode { get; set; }

        public string customerOrderCode { get; set; }

        public PaymentResponse paymentResponse { get; set; }

        public List<Warning> warnings { get; set; }

        public Dictionary<string, string> customerIdentifiers { get; set; }

        public string paymentStatusReason { get; set; }

        public CurrencyCode currencyCode { get; set; }

        public string token { get; set; }

        public string orderDescription { get; set; }

        public int amount { get; set; } 
    }
}
