using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [Serializable, DataContract]
    public class DeliveryAddress : Address
    {
        [DataMember]
        public string firstName { get; set; }

        [DataMember]
        public string lastName { get; set; }

    }
}
