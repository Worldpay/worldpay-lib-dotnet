using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    abstract public class AbstractCard : AbstractPaymentMethod
    {
        [DataMember]
        public int expiryMonth { get; set; }

        [DataMember]
        public int expiryYear { get; set; }

        [DataMember]
        public int? issueNumber { get; set; }

        [DataMember]
        public int? startMonth { get; set; }

        [DataMember]
        public int? startYear { get; set; }
    }
}
