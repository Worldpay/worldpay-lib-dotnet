using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class RiskSetting
    {
        public bool cvcEnabled { get; set; }

        public bool avsEnabled { get; set; }
    }
}
