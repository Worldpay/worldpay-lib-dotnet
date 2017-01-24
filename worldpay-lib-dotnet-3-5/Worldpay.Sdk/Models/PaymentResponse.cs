using System;
using System.Collections.Generic;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class PaymentResponse : AbstractCard
    {
        public string cardType { get; set; }

        public string maskedCardNumber { get; set; }

        public Address billingAddress { get; set; }

        public Dictionary<string, string> apmFields { get; set; }

    }
}
