using System.Web.Services;

namespace Worldpay.Sdk.Examples
{
    /// <summary>
    /// Service exposing the sample application's configuration for modification, e.g. API URL, keys.
    /// </summary>
    public class ConfigurationService : WebService
    {
        [WebMethod(EnableSession = true)]
        public string Test(string apiEndpoint, string jsEndpoint, string serviceKey, string clientKey)
        {
            Session["apiEndpoint"] = apiEndpoint;
            Session["js_endpoint"] = jsEndpoint;
            Session["service_key"] = serviceKey;
            Session["client_key"] = clientKey;
            return ""; // Required to prevent a console error in FF. See https://bugzilla.mozilla.org/show_bug.cgi?id=884693
        }
    }
}
