using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class WebhookSetting
    {
        public string webHookUrl { get; set; }

        public string webHookId { get; set; }

        public string creationDate { get; set; }

        public string[] events { get; set; }
    }
}
