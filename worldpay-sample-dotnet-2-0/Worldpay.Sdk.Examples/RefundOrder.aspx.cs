using System;
using System.Web.UI.WebControls;

namespace Worldpay.Sdk.Examples
{
    public partial class RefundOrder : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();
        }

        protected void OnRefund(object sender, CommandEventArgs e)
        {
            string orderCode = Request["orderCode"];
            if (orderCode == null)
            {
                throw new WorldpayException("Order code must be specified");
            }

            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);

            try
            {
                client.GetOrderService().Refund(orderCode);
                ServerResponse.Text = String.Format("Order {0} has been refunded!", orderCode);
                SuccessPanel.Visible = true;
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
        }
    }
}
