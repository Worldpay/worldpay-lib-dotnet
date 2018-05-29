using System;
using System.Diagnostics;
using System.Reflection;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Examples
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LibraryVersion.Text = FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(OrderRequest)).Location).ProductVersion;
        }
    }
}