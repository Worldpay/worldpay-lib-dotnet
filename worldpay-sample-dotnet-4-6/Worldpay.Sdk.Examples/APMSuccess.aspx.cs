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
    public partial class APMSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            onAuthorizeOrder(this, null);
        }

        protected void onAuthorizeOrder(object sender, CommandEventArgs e)
        {
            string orderCode = (string)Session["orderCode"];
            OrderResponse.Text = "APM Order <span id='order-code'>" + orderCode + "</span> has been authorized<br />";
        }
    }
}