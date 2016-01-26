using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class Warning
    {
        [DataMember]
        public string code { get; set; }

        [DataMember]
        public string message { get; set; }
    }
}
