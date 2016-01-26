using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [Serializable, DataContract]
    public class ThreeDSecureInfo
    {
         [DataMember]
         public string shopperIpAddress { get; set; }

         [DataMember]
         public string shopperSessionId { get; set; }

         [DataMember]
         public string shopperAcceptHeader { get; set; }

         [DataMember]
         public string shopperUserAgent { get; set; }
    }
}
