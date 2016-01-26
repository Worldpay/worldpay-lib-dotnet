using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    abstract public class AbstractTokenRequest
    {
        [DataMember]
        public string clientKey { get; set; }
    }
}
