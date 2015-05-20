using System.Runtime.Serialization;

namespace WorldPay.Sdk.Models
{
    [DataContract]
    public class CaptureRequest
    {
        [DataMember]
        public int captureAmount { get; set; }
    }
}
