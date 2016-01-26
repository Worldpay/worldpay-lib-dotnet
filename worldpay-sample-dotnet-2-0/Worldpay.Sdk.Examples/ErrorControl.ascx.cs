using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Examples
{
    public partial class ErrorControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DisplayError(ApiError apiError)
        {
            ErrorPanel.Visible = true;
            ErrorCode.Text = apiError.customCode;
            HttpStatus.Text = apiError.httpStatusCode.ToString();
            ErrorDescription.Text = apiError.description;
            ErrorMessage.Text = apiError.message;
        }
    }
}