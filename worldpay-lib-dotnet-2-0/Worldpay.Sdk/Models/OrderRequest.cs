using System;
using System.Collections.Generic;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class OrderRequest : AbstractOrder
    {
        public OrderRequest()
        {
            this.threeDSecureInfo = new ThreeDSecureInfo();
        }

        public string name { get; set; }

        public Address billingAddress { get; set; }

        public Dictionary<string, string> customerIdentifiers { get; set; }

        public string customerOrderCode { get; set; }

        public string orderType { get; set; }

        public ThreeDSecureInfo threeDSecureInfo { get; set; }

        public string shopperIpAddress
        {
            get { return threeDSecureInfo.shopperIpAddress; }
            set { threeDSecureInfo.shopperIpAddress = value; }
        }

        public string shopperSessionId
        {
            get { return threeDSecureInfo.shopperSessionId; }
            set { threeDSecureInfo.shopperSessionId = value; }
        }

        public string shopperUserAgent
        {
            get { return threeDSecureInfo.shopperUserAgent; }
            set { threeDSecureInfo.shopperUserAgent = value; }
        }

        public string shopperAcceptHeader
        {
            get { return threeDSecureInfo.shopperAcceptHeader; }
            set { threeDSecureInfo.shopperAcceptHeader = value; }
        }

        public bool is3DSOrder { get; set; }
    }
}
