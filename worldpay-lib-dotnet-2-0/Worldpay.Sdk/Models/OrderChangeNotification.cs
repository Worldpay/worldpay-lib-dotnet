using System;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class OrderChangeNotification
    {
        public string merchantId { get; set; }

        public string notificationEventType { get; set; }

        public string adminCode { get; set; }

        public string orderCode { get; set; }

        public OrderStatus paymentStatus { get; set; }

        public string environment { get; set; }
    }
}
