using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class TokenRequest : AbstractTokenRequest
    {
        [DataMember]
        public AbstractPaymentMethod paymentMethod { get; set; }

        [DataMember]
        public bool reusable { get; set; }
    }
}
