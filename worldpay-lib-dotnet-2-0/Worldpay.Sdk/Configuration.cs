using System;
using System.Configuration;

namespace Worldpay.Sdk
{
    public class Configuration
    {
        /// <summary>
        /// Uri of the token request API
        /// </summary>
        public static string TokenUrl
        {
            get { return ConfigurationManager.AppSettings["TokenUrl"]; }
        }

        /// <summary>
        /// Base Uri of the service
        /// </summary>
        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"]; }
        }

        /// <summary>
        /// The secret key for service authorization
        /// </summary>
        public static string ServiceKey
        {
            get { return ConfigurationManager.AppSettings["ServiceKey"]; }
        }

        /// <summary>
        /// The merchant id corresponding to the service and client key
        /// </summary>
        public static string MerchantId
        {
            get { return ConfigurationManager.AppSettings["MerchantId"]; }
        }

        /// <summary>
        /// The client key for service authorization
        /// </summary>
        public static string ClientKey
        {
            get { return ConfigurationManager.AppSettings["ClientKey"]; }
        }


        public static string OrderLog
        {
            get { return ConfigurationManager.AppSettings["OrderLog"]; }
        }


        public static string WebhookUrl
        {
            get { return ConfigurationManager.AppSettings["WebhookUrl"]; }
        }
    }
}
