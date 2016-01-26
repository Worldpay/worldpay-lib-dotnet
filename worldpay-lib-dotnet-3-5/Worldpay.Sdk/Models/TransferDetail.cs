using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class TransferDetail
    {
        [DataMember]
        public string transferId { get; set; }

        [DataMember]
        public TransferOrder orders { get; set; }
    }
}
