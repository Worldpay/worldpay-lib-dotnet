using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class Setting
    {
        public string keyType { get; set; }

        public string environment { get; set; }

        public bool enabled { get; set; }

        public string key { get; set; }
    }
}
