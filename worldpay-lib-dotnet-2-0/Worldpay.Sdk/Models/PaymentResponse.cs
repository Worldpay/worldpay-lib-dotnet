using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class PaymentResponse : AbstractCard
    {
        public string cardType { get; set; }

        public string maskedCardNumber { get; set; }

        public Address billingAddress { get; set; }
    }
}
