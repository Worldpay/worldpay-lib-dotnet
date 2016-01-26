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
            int refundAmount = 0;
            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);
            string orderCode = Request["orderCode"];

            if (orderCode == null)
            {
                throw new WorldpayException("Order code must be specified");
            }

            try
            {
                refundAmount = Int32.Parse(Request["amount"]);
            }
            catch (Exception exc) { }

            try
            {
                client.GetOrderService().Refund(orderCode, refundAmount);
                if (refundAmount == 0)
                {
                    ServerResponse.Text = String.Format("Order <span id='order-code'>{0}</span> has been refunded for the full amount", orderCode);
                }
                else
                {
                    ServerResponse.Text = String.Format("Order <span id='order-code'>{0}</span> has been refunded for {1}", orderCode, refundAmount);
                }
                SuccessPanel.Visible = true;
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
        }
    }
}
