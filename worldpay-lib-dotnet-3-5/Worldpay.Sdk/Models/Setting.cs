using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class Setting
    {
        [DataMember]
        public string keyType { get; set; }

        [DataMember]
        public string environment { get; set; }

        [DataMember]
        public bool enabled { get; set; }

        [DataMember]
        public string key { get; set; }
    }
}
