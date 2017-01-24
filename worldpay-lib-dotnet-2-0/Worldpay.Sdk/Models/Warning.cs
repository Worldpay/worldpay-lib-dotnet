using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class Warning
    {
        public string code { get; set; }

        public string message { get; set; }
    }
}
