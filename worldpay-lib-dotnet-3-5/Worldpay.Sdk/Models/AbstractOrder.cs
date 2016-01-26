using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [DataContract]
    public class AbstractOrder
    {
        [DataMember]
        public string token { get; set; }

        [DataMember]
        public string orderDescription { get; set; }

        [DataMember]
        public int? amount { get; set; }

        [DataMember]
        public string currencyCode { get; set; }

        [DataMember]
        public string settlementCurrency { get; set; }

        [DataMember]
        public bool authorizeOnly { get; set; }

        [DataMember]
        public int? authorizedAmount { get; set; }
    }
}
