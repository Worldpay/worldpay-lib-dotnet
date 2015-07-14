using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Json;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class OrderResponse : AbstractOrder
    {
        [DataMember]
        public string orderCode { get; set; }

        [DataMember]
        public OrderStatus paymentStatus { get; set; }

        [DataMember]
        public string paymentStatusReason { get; set; }
        
        [DataMember]
        public PaymentResponse paymentResponse { get; set; }

        [DataMember]
        public string customerOrderCode { get; set; }

        [DataMember]
        public bool is3DSOrder { get; set; }

        [DataMember]
        public string oneTime3DsToken { get; set; }

        [DataMember]
        public string redirectURL { get; set; }

        [DataMember, JsonConverter(typeof(EntryConverter))]
        public List<Entry> customerIdentifiers { get; set; }

        [DataMember]
        public Environment environment { get; set; }
    }
}
