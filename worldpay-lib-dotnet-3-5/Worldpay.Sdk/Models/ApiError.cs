using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class ApiError
    {
        public int httpStatusCode { get; set; }

        public string customCode { get; set; }

        public string message { get; set; }

        public string description { get; set; }

        public string errorHelpUrl { get; set; }

        public string originalRequest { get; set; }
    }
}
