using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class TokenResponse
    {
        [DataMember]
        public string token { get; set; }

        [DataMember]
        public PaymentResponse paymentMethod { get; set; }

        [DataMember]
        public bool reusable { get; set; }
    }
}
