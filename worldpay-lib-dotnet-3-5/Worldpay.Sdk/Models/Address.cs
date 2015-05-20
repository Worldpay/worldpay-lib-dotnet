using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [Serializable, DataContract]
    public class Address
    {
        [DataMember]
        public string address1 { get; set; }

        [DataMember]
        public string address2 { get; set; }

        [DataMember]
        public string address3 { get; set; }

        [DataMember]
        public string postalCode { get; set; }

        [DataMember]
        public string city { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember, JsonConverter(typeof(StringEnumConverter))]
        public CountryCode countryCode { get; set; }
    }
}
