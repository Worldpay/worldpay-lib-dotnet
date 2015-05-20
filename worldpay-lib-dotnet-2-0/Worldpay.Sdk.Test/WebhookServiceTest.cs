using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Test
{
    [TestClass]
    public class WebhookServiceTest
    {
        [TestMethod]
        public void shouldLogOrderStatus()
        {
            var logFile = new FileInfo(Configuration.OrderLog);
            logFile.Delete();

            var adminCode = "testAdminCode";
            var environment = "test";
            var merchantId = "testMerchant";
            var notificationEventType = "ORDER CHANGED";
            var orderCode = "testCode";
            var status = OrderStatus.SUCCESS;

            var notification = new OrderChangeNotification()
            {
                adminCode = adminCode,
                environment = environment,
                merchantId = merchantId,
                notificationEventType = notificationEventType,
                orderCode = orderCode,
                paymentStatus = status
            };

            var request = (HttpWebRequest) HttpWebRequest.Create(Configuration.WebhookUrl);
            request.ContentType = "application/json";
            request.Method = "POST";

            var serializedData = new JavaScriptSerializer().Serialize(notification);
            var bytes = Encoding.ASCII.GetBytes(serializedData);
            request.ContentLength = bytes.Length;

            using (Stream outputStream = request.GetRequestStream())
            {
                outputStream.Write(bytes, 0, bytes.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
            
            using (var reader = new StreamReader(new FileStream(Configuration.OrderLog, FileMode.Open)))
            {
                var firstLine = reader.ReadLine();
                Assert.AreEqual(String.Format("{0}: {1} {2}", notificationEventType, orderCode, status.ToString()), firstLine);

                var secondLine = reader.ReadLine();
                Assert.AreEqual(null, secondLine);
            }
        }
    }
}
