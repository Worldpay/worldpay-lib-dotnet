using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Worldpay.Sdk.Examples
{
    public partial class CaptureAuthorizedOrder : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();
        }

        protected void OnCaptureOrder(object sender, CommandEventArgs e)
        {
            var form = HttpContext.Current.Request.Form;
            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);

            var orderCode = form["orderCode"];
            var amount = 0;

            try
            {
                amount = Int32.Parse(form["amount"]);
            }
            catch (Exception exc) { }

            try
            {
                var response = client.GetOrderService().CaptureAuthorizedOrder(orderCode, amount);

                ServerResponse.Text = "Order code:" + response.orderCode +
                                        "<br />Payment Status: " + response.paymentStatus +
                                        "<br />Environment: " + response.environment;
                SuccessPanel.Visible = true;
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
            catch (Exception exc)
            {
                throw new InvalidOperationException("Error sending request ", exc);
            }
        }
    }
}