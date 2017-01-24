using System.Web;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    public class WebhookService : AbstractService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public WebhookService(Http http) : base(http)
        {

        }

        /// <summary>
        /// Handle an order webhook
        /// </summary>
        /// <param name="request">The incoming web request</param>
        /// <returns>Order response data</returns>
        public OrderChangeNotification ProcessWebhook(HttpRequest request)
        {
            return Http.HandleRequest<OrderChangeNotification>(request);
        }
    }
}
