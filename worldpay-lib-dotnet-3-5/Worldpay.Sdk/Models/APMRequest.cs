using System.Collections.Generic;

namespace Worldpay.Sdk.Models
{
    public class APMRequest : AbstractPaymentMethod
    {
        public APMRequest()
        {
            this.type = "APM";
        }

        public string apmName { get; set; }

        public string shopperCountryCode { get; set; }

        public Dictionary<string, string> apmFields { get; set; }
    }
}
