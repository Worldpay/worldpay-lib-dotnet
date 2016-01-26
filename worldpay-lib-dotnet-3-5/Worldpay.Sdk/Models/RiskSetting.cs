using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class RiskSetting
    {
        [DataMember]
        public bool cvcEnabled { get; set; }

        [DataMember]
        public bool avsEnabled { get; set; }
    }
}
