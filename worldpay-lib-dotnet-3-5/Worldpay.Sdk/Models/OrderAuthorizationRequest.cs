namespace Worldpay.Sdk.Models
{
    class OrderAuthorizationRequest
    {
        public OrderAuthorizationRequest()
        {
            this.threeDSecureInfo = new ThreeDSecureInfo();
        }

        public string threeDSResponseCode { get; set; }

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
    }
}
