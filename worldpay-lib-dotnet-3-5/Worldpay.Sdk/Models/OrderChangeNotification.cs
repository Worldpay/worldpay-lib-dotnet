using System;
using System.Runtime.Serialization;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class OrderChangeNotification
    {
        [DataMember]
        public string merchantId { get; set; }

        [DataMember]
        public string notificationEventType { get; set; }

        [DataMember]
        public string adminCode { get; set; }

        [DataMember]
        public string orderCode { get; set; }

        [DataMember]
        public OrderStatus paymentStatus { get; set; }

        [DataMember]
        public string environment { get; set; }
    }
}
