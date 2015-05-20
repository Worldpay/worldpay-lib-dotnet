using System.Runtime.Serialization;

namespace WorldPay.Sdk.Models
{
    [DataContract]
    class PartialRefundRequest
    {
        [DataMember]
        public int refundAmount { get; set; }
    }
}
