using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Worldpay.Sdk.Json;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class SettingsResponse
    {
        [DataMember]
        public List<Setting> keys { get; set; }

        [DataMember]
        public RiskSetting riskSetting { get; set; }

        [DataMember]
        public MerchantOrderSetting orderSetting { get; set; }

        [DataMember]
        public List<WebhookSetting> webhooks { get; set; }

        [DataMember]
        public string webhookKey { get; set; }
    }
}
