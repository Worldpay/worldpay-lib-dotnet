using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class PaymentResponse : AbstractCard
    {
        [DataMember]
        public string cardType { get; set; }

        [DataMember]
        public string maskedCardNumber { get; set; }

        [DataMember]
        public Address billingAddress { get; set; }
    }
}
