using System;
using System.IO;
using System.Web;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Examples
{
    public partial class Webhook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var client = new WorldpayRestClient("your service key");
                var response = client.GetWebhookService().ProcessWebhook(HttpContext.Current.Request);

                switch (response.paymentStatus)
                {
                    case OrderStatus.SUCCESS:
                        // The order has been successful
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.REFUNDED:
                        // The order has been refunded
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.FAILED:
                        // The order has failed
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.SETTLED:
                        // The order has been settled                        
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.CHARGED_BACK:
                        // The order has been charged back
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.INFORMATION_REQUESTED:
                        // Information requested about the order
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.INFORMATION_SUPPLIED:
                        // Information has been supplied about the order
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.CHARGEBACK_REVERSED:
                        // The order's charge back has been reversed
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                    case OrderStatus.EXPIRED:
                        // The order is expired
                        Record(response.notificationEventType, response.orderCode, response.paymentStatus);
                        break;
                }

                Response.StatusCode = 200;
            }
            catch (WorldpayException exc)
            {
                RecordError(exc);
                Response.StatusCode = 500;
                Response.StatusDescription = exc.Message;
                Response.End();
            }
        }

        private void Record(string notificationType, string code, OrderStatus status)
        {
            using (var writer = new StreamWriter(new FileStream(Configuration.OrderLog, FileMode.Append)))
            {
                writer.WriteLine("{0}: {1} {2}", notificationType, code, status);
            }
        }

        private void RecordError(Exception exc)
        {
            using (var writer = new StreamWriter(new FileStream(Configuration.OrderLog, FileMode.Append)))
            {
                writer.WriteLine(exc.ToString());
            }
        }

    }
}