using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Worldpay.Sdk;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Worldpay.Sdk.Examples
{
    public partial class RecurringPayment : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();

            if (IsPostBack)
            {
                RequestPanel.Visible = false;
                OnCreateOrder(this, null);
            }
        }

        protected void OnCreateOrder(object sender, CommandEventArgs e)
        {
            var form = HttpContext.Current.Request.Form;
            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);
            var orderType = (OrderType)Enum.Parse(typeof(OrderType), form["orderType"]);
            int? _amount = 0;
            var _currencyCode = "";
            Dictionary<string, string> custIdentifiers = new Dictionary<string, string>();

            try
            {
                if (!string.IsNullOrEmpty(form["amount"]))
                {
                    double n;
                    bool isNumeric = double.TryParse(form["amount"], out n);
                    _amount = isNumeric ? (int)(Convert.ToDecimal(form["amount"]) * 100) : -1;
                }
            }
            catch (Exception excAmount) { }

            try
            {
                _currencyCode = Enum.Parse(typeof(CurrencyCode), form["currency"]).ToString();
            }
            catch (Exception excCurrency) { }

            try
            {
                custIdentifiers = JavaScriptConvert.DeserializeObject<Dictionary<string, string>>(form["customer-identifiers"]);

            }
            catch (Exception exc) { }

            var billingAddress = new Address()
            {
                address1 = form["address1"],
                address2 = form["address2"],
                address3 = form["address3"],
                postalCode = form["postcode"],
                city = form["city"],
                state = "",
                countryCode = Enum.Parse(typeof(CountryCode), form["countryCode"]).ToString()
            };

            var deliveryAddress = new DeliveryAddress()
            {
                firstName = form["delivery-firstName"],
                lastName = form["delivery-lastName"],
                address1 = form["delivery-address1"],
                address2 = form["delivery-address2"],
                address3 = form["delivery-address3"],
                postalCode = form["delivery-postcode"],
                city = form["delivery-city"],
                state = "",
                countryCode = Enum.Parse(typeof(CountryCode), form["delivery-countryCode"]).ToString()
            };

            var is3DS = form["3ds"] == "on" ? true : false;
            ThreeDSecureInfo threeDSInfo = null;
            if (is3DS)
            {
                var httpRequest = HttpContext.Current.Request;
                threeDSInfo = new ThreeDSecureInfo()
                {
                    shopperIpAddress = httpRequest.UserHostAddress,
                    shopperSessionId = HttpContext.Current.Session.SessionID,
                    shopperUserAgent = httpRequest.UserAgent,
                    shopperAcceptHeader = String.Join(";", httpRequest.AcceptTypes)
                };
            }

            var request = new OrderRequest
                {
                    token = form["token"],
                    orderDescription = form["description"],
                    statementNarrative = form["statement-narrative"],
                    billingAddress = billingAddress,
                    deliveryAddress = deliveryAddress,
                    amount = _amount,
                    currencyCode = _currencyCode,
                    name = is3DS && Session["mode"].Equals("test") ? "3D" : form["name"],
                    threeDSecureInfo = is3DS ? threeDSInfo : new ThreeDSecureInfo(),
                    is3DSOrder = is3DS,
                    customerOrderCode = form["customer-order-code"],
                    orderCodePrefix = form["order-code-prefix"],
                    orderCodeSuffix = form["order-code-suffix"],
                    shopperEmailAddress = form["shopper-email"],
                    customerIdentifiers = custIdentifiers,                
                    authorizeOnly = form["authorizeOnly"] == "on",
                    orderType = orderType.ToString()
            };

            if (!string.IsNullOrEmpty(form["settlement-currency"]))
            {
                request.settlementCurrency = form["settlement-currency"];
            }
            if (!string.IsNullOrEmpty(form["site-code"]))
            {
                request.siteCode = form["site-code"];
            }

            try
            {
                var response = client.GetOrderService().Create(request);
                HandleSuccessResponse(response);
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
            catch (Exception exc)
            {
                throw new InvalidOperationException("Error sending request with token " + request.token, exc);
            }
        }

        private void HandleSuccessResponse(OrderResponse response)
        {
            if (response.paymentStatus == OrderStatus.PRE_AUTHORIZED && response.is3DSOrder)
            {
                Handle3DSResponse(response);
                return;
            }

            ResponseOrderCode.Text = response.orderCode;
            ResponseToken.Text = response.token;
            ResponsePaymentStatus.Text = response.paymentStatus.ToString();
            ResponseJson.Text = JavaScriptConvert.SerializeObject(response);
            SuccessPanel.Visible = true;
        }

        private void Handle3DSResponse(OrderResponse response)
        {
            Session["orderCode"] = response.orderCode;
            Response.Clear();

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""submitForm""].submit()'>");
            sb.AppendFormat("<form name='submitForm' action='{0}' method='post'>", response.redirectURL);
            sb.AppendFormat("<input type='hidden' name='PaReq' value='{0}'>", response.oneTime3DsToken);
            sb.AppendFormat("<input type='hidden' name='TermUrl' id='termUrl' value='{0}'>", response.redirectURL);
            sb.Append("<script>\n" +
                      "  document.getElementById('termUrl').value =\n" +
                      "  window.location.href.replace('RecurringPayment', 'AuthorizeOrder');" +
                      "</script>");
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            Response.Write(sb.ToString());
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}