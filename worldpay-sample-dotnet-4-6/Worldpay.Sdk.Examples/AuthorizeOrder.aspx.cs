using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Worldpay.Sdk;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Examples
{
    public partial class AuthorizeOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            onAuthorizeOrder(this, null);
        }

        protected void onAuthorizeOrder(object sender, CommandEventArgs e)
        {
            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);

            string orderCode = (string)Session["orderCode"];
            var responseCode = HttpContext.Current.Request.Form["PaRes"];
            var httpRequest = HttpContext.Current.Request;
            ThreeDSecureInfo threeDSInfo = new ThreeDSecureInfo()
            {
                shopperIpAddress = httpRequest.UserHostAddress,
                shopperSessionId = HttpContext.Current.Session.SessionID,
                shopperUserAgent = httpRequest.UserAgent,
                shopperAcceptHeader = String.Join(";", httpRequest.AcceptTypes)
            };

            try
            {
                var response = client.GetOrderService().Authorize(orderCode, responseCode, threeDSInfo);
                OrderResponse.Text = "Order code:<span id='order-code'>" + response.orderCode + "</span><br />Payment Status: " +
                                            response.paymentStatus + "<br />Environment: " + response.environment;
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
            catch (Exception exc)
            {
                throw new InvalidOperationException("Error sending request with order code " + orderCode, exc);
            }
        }
    }
}