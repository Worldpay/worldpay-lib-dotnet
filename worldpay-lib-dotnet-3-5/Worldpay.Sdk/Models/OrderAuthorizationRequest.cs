using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Worldpay.Sdk.Models
{
    class OrderAuthorizationRequest
    {
        public OrderAuthorizationRequest()
        {
            this.threeDSecureInfo = new ThreeDSecureInfo();
        }
        [DataMember]
        public string threeDSResponseCode { get; set; }

        public ThreeDSecureInfo threeDSecureInfo { get; set; }

        [DataMember]
        public string shopperIpAddress
        {
            get { return threeDSecureInfo.shopperIpAddress; }
            set { threeDSecureInfo.shopperIpAddress = value; }
        }

        [DataMember]
        public string shopperSessionId
        {
            get { return threeDSecureInfo.shopperSessionId; }
            set { threeDSecureInfo.shopperSessionId = value; }
        }

        [DataMember]
        public string shopperUserAgent
        {
            get { return threeDSecureInfo.shopperUserAgent; }
            set { threeDSecureInfo.shopperUserAgent = value; }
        }

        [DataMember]
        public string shopperAcceptHeader
        {
            get { return threeDSecureInfo.shopperAcceptHeader; }
            set { threeDSecureInfo.shopperAcceptHeader = value; }
        }
    }
}
