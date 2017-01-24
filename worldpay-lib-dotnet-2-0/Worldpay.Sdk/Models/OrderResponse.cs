using System.Collections.Generic;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    public class OrderResponse : AbstractOrder
    {
        public string orderCode { get; set; }

        public OrderStatus paymentStatus { get; set; }

        public string paymentStatusReason { get; set; }
        
        public PaymentResponse paymentResponse { get; set; }

        public string customerOrderCode { get; set; }

        public bool is3DSOrder { get; set; }

        public string oneTime3DsToken { get; set; }

        public string redirectURL { get; set; }

        public Dictionary<string, string> customerIdentifiers { get; set; }

        public Environment environment { get; set; }

        public string shopperEmailAddress { get; set; }

        public DeliveryAddress deliveryAddress { get; set; }

        public string statementNarrative { get; set; }

    }
}
