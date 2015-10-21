using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Json;

namespace Worldpay.Sdk.Models
{
    [Serializable, DataContract]
    public class OrderRequest : AbstractOrder
    {
        public OrderRequest()
        {
            this.threeDSecureInfo = new ThreeDSecureInfo();
        }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public Address billingAddress { get; set; }
        
        [DataMember]
        public DeliveryAddress deliveryAddress { get; set; }

        [DataMember]
        public Dictionary<string, string> customerIdentifiers { get; set; }

        [DataMember]
        public string customerOrderCode { get; set; }

        [DataMember, JsonConverter(typeof(StringEnumConverter))]
        public OrderType? orderType { get; set; }

        public ThreeDSecureInfo threeDSecureInfo { get; set; }

        [DataMember]
        public string shopperIpAddress { get { return threeDSecureInfo.shopperIpAddress; }
                                         set { threeDSecureInfo.shopperIpAddress = value; } }

        [DataMember]
        public string shopperSessionId { get { return threeDSecureInfo.shopperSessionId; } 
                                         set { threeDSecureInfo.shopperSessionId = value; } }

        [DataMember]
        public string shopperUserAgent { get { return threeDSecureInfo.shopperUserAgent; } 
                                         set { threeDSecureInfo.shopperUserAgent = value; } }

        [DataMember]
        public string shopperAcceptHeader { get { return threeDSecureInfo.shopperAcceptHeader; }
                                         set { threeDSecureInfo.shopperAcceptHeader = value; } }

        [DataMember]
        public bool is3DSOrder { get; set; }

        [DataMember]
        public string successUrl { get; set; }

        [DataMember]
        public string failureUrl { get; set; }

        [DataMember]
        public string cancelUrl { get; set; }

        [DataMember]
        public string pendingUrl { get; set; }

        [DataMember]
        public string shopperEmailAddress { get; set; }

    }
}
