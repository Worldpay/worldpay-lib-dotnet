using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Worldpay.Sdk.Examples
{
    public partial class CancelAuthorizedOrder : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();
        }

        protected void OnCancelOrder(object sender, CommandEventArgs e)
        {
            var form = HttpContext.Current.Request.Form;
            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);

            var orderCode = form["orderCode"];

            try
            {
                client.GetOrderService().CancelAuthorizedOrder(orderCode);
                ServerResponse.Text = String.Format("Authorized order {0} has been cancelled", orderCode);
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