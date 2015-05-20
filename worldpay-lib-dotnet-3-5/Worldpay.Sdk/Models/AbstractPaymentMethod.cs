using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class AbstractPaymentMethod
    {
        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public Address address { get; set; }
    }
}
