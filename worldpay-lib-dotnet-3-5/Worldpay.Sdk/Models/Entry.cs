using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class Entry
    {
        public string key { get; set; }

        public string value { get; set; }

        public Entry()
        {
            
        }

        public Entry(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
