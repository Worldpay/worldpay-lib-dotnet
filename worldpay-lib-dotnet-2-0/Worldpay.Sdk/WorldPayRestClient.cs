using System.IO;
using WorldPay.Sdk;

namespace Worldpay.Sdk
{
    /// <summary>
    /// Master client for interacting with Worldpay REST services
    /// </summary>
    public class WorldpayRestClient
    {
        /// <summary>
        /// The base url for the REST service
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// The service key for authorizing access
        /// </summary>
        private readonly string _serviceKey;

        /// <summary>
        /// Constructor
        /// </summary>
        public WorldpayRestClient(string baseUrl, string serviceKey)
        {
            if (baseUrl == null)
            {
                throw new InvalidDataException("baseUrl cannot be null");
            }

            _baseUrl = baseUrl;

            if (serviceKey == null)
            {
                throw new InvalidDataException("serviceKey cannot be null");
            }

            _serviceKey = serviceKey;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WorldpayRestClient(string serviceKey) : this(Configuration.BaseUrl, serviceKey) { }

        /// <summary>
        /// Get service for interacting with authorization API
        /// </summary>
        public AuthService GetAuthService()
        {
            return new AuthService(new Http());
        }

        public TokenService GetTokenService()
        {
            return new TokenService(_baseUrl, new Http(_serviceKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MerchantService GetMerchantService()
        {
            return new MerchantService(_baseUrl, new Http(_serviceKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrderService GetOrderService()
        {
            return new OrderService(_baseUrl, new Http(_serviceKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SettingsService GetSettingsService()
        {
            return new SettingsService(_baseUrl, new Http(_serviceKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WebhookService GetWebhookService()
        {
            return new WebhookService(new Http(_serviceKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TransferService GetTransferService()
        {
            return new TransferService(_baseUrl, new Http(_serviceKey));
        }
    }
}
