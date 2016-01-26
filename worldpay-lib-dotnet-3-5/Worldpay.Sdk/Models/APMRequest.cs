using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Worldpay.Sdk.Json;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class APMRequest : AbstractPaymentMethod
    {
        [DataMember]
        public string apmName { get; set; }

        [DataMember]
        public string shopperCountryCode { get; set; }

        [DataMember, JsonConverter(typeof(EntryConverter))]
        public List<Entry> apmFields { get; set; }
    }
}
