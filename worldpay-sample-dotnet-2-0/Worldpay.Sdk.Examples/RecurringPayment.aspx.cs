using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Worldpay.Sdk;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Examples
{
    public partial class RecurringPayment : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();
        }

        protected void OnCreateOrder(object sender, CommandEventArgs e)
        {
            var form = HttpContext.Current.Request.Form;
            var client = new WorldpayRestClient((string) Session["service_key"]);

            var request = new OrderRequest
                {
                    token = form["token"],
                    orderDescription = form["description"],
                    amount = (int) (Convert.ToDecimal(form["amount"])*100),
                    currencyCode = Enum.Parse(typeof (CurrencyCode), form["currency"]).ToString(),
                    orderType = OrderType.RECURRING.ToString()
                };

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
            ResponseOrderCode.Text = response.orderCode;
            ResponseToken.Text = response.token;
            ResponsePaymentStatus.Text = response.paymentStatus.ToString();
            ResponseJson.Text = JsonUtils.SerializeObject(response);
            SuccessPanel.Visible = true;
        }
    }
}