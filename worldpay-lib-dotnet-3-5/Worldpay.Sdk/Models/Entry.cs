using System;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [Serializable, DataContract]
    public class Entry
    {
        [DataMember]
        public string key { get; set; }

        [DataMember]
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
