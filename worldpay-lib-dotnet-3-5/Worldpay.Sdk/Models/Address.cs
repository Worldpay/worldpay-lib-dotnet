using System;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class Address
    {
        public string address1 { get; set; }

        public string address2 { get; set; }

        public string address3 { get; set; }

        public string postalCode { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string countryCode { get; set; }

        public string telephoneNumber { get; set; }
    }
}
