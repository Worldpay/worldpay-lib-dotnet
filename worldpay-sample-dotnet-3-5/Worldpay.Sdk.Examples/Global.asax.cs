using System;
using System.Configuration;
using Configuration = Worldpay.Sdk.Configuration;

namespace Worldpay.Sdk.Examples
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Set configuration to default values
            Session["apiEndpoint"] = Configuration.BaseUrl;
            Session["js_endpoint"] = ConfigurationManager.AppSettings["JsEndpoint"];
            Session["service_key"] = Configuration.ServiceKey;
            Session["client_key"] = Configuration.ClientKey;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
