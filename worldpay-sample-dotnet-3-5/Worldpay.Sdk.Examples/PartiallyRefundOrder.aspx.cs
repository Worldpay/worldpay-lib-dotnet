using System;
using System.Web.UI.WebControls;

namespace Worldpay.Sdk.Examples
{
    public partial class PartiallyRefundOrder : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();
        }

        protected void OnPartialRefund(object sender, CommandEventArgs e)
        {
            string orderCode = Request["orderCode"];
            if (orderCode == null)
            {
                throw new WorldpayException("Order code must be specified");
            }

            int refundAmount = Int32.Parse(Request["amount"]);

            var client = new WorldpayRestClient(Configuration.ServiceKey);

            try
            {
                client.GetOrderService().Refund(orderCode, refundAmount);
                ServerResponse.Text = String.Format("Order {0} has been refunded for {1}", orderCode, refundAmount);
                SuccessPanel.Visible = true;
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
        }
    }
}
