using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class AbstractPaymentMethod
    {
        [DataMember]
        public string type { get; set; }
    }
}
