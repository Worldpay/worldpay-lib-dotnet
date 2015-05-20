using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class CardRequest : AbstractCard
    {
        [DataMember]
        public string cardNumber { get; set; }

        [DataMember]
        public string cvc { get; set; }


    }
}
