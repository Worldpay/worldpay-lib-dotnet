using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Worldpay.Sdk;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Examples
{
    public partial class GetOrder : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();
        }

        protected void OnGetOrder(object sender, CommandEventArgs e)
        {
            string orderCode = Request["orderCode"];
            if (orderCode == null)
            {
                throw new WorldpayException("Order code must be specified");
            }

            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);

            try
            {
                var response = client.GetOrderService().FindOrder(orderCode);
                ServerResponse.Text = JavaScriptConvert.SerializeObject(response);
                SuccessPanel.Visible = true;
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
        }
    }
}