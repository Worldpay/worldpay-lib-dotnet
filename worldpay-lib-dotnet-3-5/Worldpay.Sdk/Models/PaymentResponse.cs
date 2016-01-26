using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Worldpay.Sdk.Json;

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

        [DataMember, JsonConverter(typeof(EntryConverter))]
        public List<Entry> apmFields { get; set; }
    }
}
