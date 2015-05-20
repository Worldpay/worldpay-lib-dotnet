using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class WebhookSetting
    {
        [DataMember]
        public string webHookUrl { get; set; }

        [DataMember]
        public string webHookId { get; set; }

        [DataMember]
        public string creationDate { get; set; }

        [DataMember]
        public string[] events { get; set; }
    }
}
