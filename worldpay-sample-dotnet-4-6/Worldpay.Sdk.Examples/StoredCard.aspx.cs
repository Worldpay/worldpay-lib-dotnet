using System;
using System.Web.UI.WebControls;
using Worldpay.Sdk.Examples;
using Worldpay.Sdk.Models;
using Newtonsoft.Json;

namespace Worldpay.Sdk.Examples
{
    public partial class StoredCard : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataBind();
        }

        protected void OnShowCardDetails(object sender, CommandEventArgs e)
        {
            var token = Request["token"];
            var client = new WorldpayRestClient((string)Session["apiEndpoint"], (string)Session["service_key"]);

            try
            {
                var details = client.GetTokenService().Get(token);
                HandleSuccessResponse(details);
            }
            catch (WorldpayException exc)
            {
                ErrorControl.DisplayError(exc.apiError);
            }
        }

        private void HandleSuccessResponse(TokenResponse details)
        {
            ResultName.Text = details.paymentMethod.name;
            ResultMonth.Text = details.paymentMethod.expiryMonth.ToString();
            ResultYear.Text = details.paymentMethod.expiryYear.ToString();
            ResultType.Text = details.paymentMethod.cardType;
            ResultCardNumber.Text = details.paymentMethod.maskedCardNumber;
            ResponseJson.Text = JavaScriptConvert.SerializeObject(details);
            SuccessPanel.Visible = true;
        }
    }
}
