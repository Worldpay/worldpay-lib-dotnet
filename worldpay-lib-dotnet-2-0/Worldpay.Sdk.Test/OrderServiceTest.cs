using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Worldpay.Sdk.Enums;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        /// <summary>
        /// Authorization service, for obtaining access tokens
        /// </summary>
        private AuthService _authService;

        /// <summary>
        /// Order service, for handling interaction with the order API
        /// </summary>
        private OrderService _orderService;

        /// <summary>
        /// Initialise the service clients
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            var restClient = new WorldpayRestClient(Configuration.ServiceKey);
            _authService = restClient.GetAuthService();
            _orderService = restClient.GetOrderService();
        }

        /// <summary>
        /// Verify that creating an order works for a valid token
        /// </summary>
        [TestMethod]
        public void ShouldCreateOrderForValidToken()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();

            OrderResponse response = _orderService.Create(orderRequest);

            Assert.IsNotNull(response.orderCode);
            Assert.AreEqual(1999, response.amount);
            Assert.IsNotNull(response.customerIdentifiers);
        }

        [TestMethod]
        public void ShouldCreateTelephoneOrder()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();
            orderRequest.orderType = OrderType.MOTO.ToString();

            OrderResponse response = _orderService.Create(orderRequest);

            Assert.IsNotNull(response.orderCode);
            Assert.AreEqual(1999, response.amount);
            Assert.IsNotNull(response.customerIdentifiers);
        }

        [TestMethod]
        public void ShouldCreateAuthorisationRequest()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();
            orderRequest.authorizeOnly = true;

            OrderResponse response = _orderService.Create(orderRequest);

            Assert.IsNotNull(response.orderCode);
            Assert.AreEqual(1999, response.authorizedAmount);
            Assert.IsTrue(response.authorizeOnly);
            Assert.AreEqual(OrderStatus.AUTHORIZED, response.paymentStatus);
        }

        [TestMethod]
        public void ShouldCapturePaymentForAuthorizedOrder()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();
            orderRequest.authorizeOnly = true;

            string orderCode = _orderService.Create(orderRequest).orderCode;

            OrderResponse response = _orderService.CaptureAuthorizedOrder(orderCode);

            Assert.IsNotNull(response.orderCode);
            Assert.AreEqual(1999, response.authorizedAmount);
            Assert.AreEqual(1999, response.amount);
            Assert.AreEqual(OrderStatus.SUCCESS, response.paymentStatus);
        }

        [TestMethod]
        public void ShouldPartiallyCapturePaymentForAuthorizedOrder()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();
            orderRequest.authorizeOnly = true;

            string orderCode = _orderService.Create(orderRequest).orderCode;

            OrderResponse response = _orderService.CaptureAuthorizedOrder(orderCode, 500);

            Assert.IsNotNull(response.orderCode);
            Assert.AreEqual(1999, response.authorizedAmount);
            Assert.AreEqual(500, response.amount);
            Assert.AreEqual(OrderStatus.SUCCESS, response.paymentStatus);
        }

        [TestMethod]
        public void ShouldCancelPaymentForAuthorizedOrder()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();
            orderRequest.authorizeOnly = true;

            string orderCode = _orderService.Create(orderRequest).orderCode;

            _orderService.CancelAuthorizedOrder(orderCode);
        }

        /// <summary>
        /// Verify that creating a 3DS order works
        /// </summary>
        [TestMethod]
        public void ShouldCreate3DSOrder()
        {
            OrderRequest orderRequest = create3DSOrderRequest();
            orderRequest.token = CreateToken();

            OrderResponse response = _orderService.Create(orderRequest);

            Assert.IsNotNull(response.orderCode);
            Assert.AreEqual(1999, response.amount);
            Assert.IsNotNull(response.oneTime3DsToken);
            Assert.IsTrue(response.is3DSOrder);
            Assert.AreEqual(OrderStatus.PRE_AUTHORIZED, response.paymentStatus);
        }

        /// <summary>
        /// Verify that creating a APM order works
        /// </summary>
        [TestMethod]
        public void ShouldCreateAPMOrder()
        {
            OrderRequest orderRequest = createAPMOrderRequest();
            orderRequest.token = CreateAPMToken();

            OrderResponse response = _orderService.Create(orderRequest);

            Assert.IsNotNull(response.redirectURL);
            Assert.IsNotNull(response.orderCode);
            Assert.AreEqual(1999, response.amount);
            Assert.IsFalse(response.is3DSOrder);

            Assert.AreEqual(OrderStatus.PRE_AUTHORIZED, response.paymentStatus);
        }

        /// <summary>
        /// Vefiy that authorise 3DS Order works
        /// </summary>
        [TestMethod]
        public void ShouldAuthorise3DSOrder()
        {
            OrderRequest orderRequest = create3DSOrderRequest();
            orderRequest.token = CreateToken();

            OrderResponse response = _orderService.Create(orderRequest);

            var threeDSInfo = new ThreeDSecureInfo()
            {
                shopperIpAddress = "127.0.0.1",
                shopperSessionId = "sessionId",
                shopperUserAgent = "Mozilla/v1",
                shopperAcceptHeader = "application/json"
            };

            var authorizationResponse = _orderService.Authorize(response.orderCode, "IDENTIFIED", threeDSInfo);

            Assert.AreEqual(response.orderCode, authorizationResponse.orderCode);
            Assert.AreEqual(1999, authorizationResponse.amount);
            Assert.IsTrue(response.is3DSOrder);
            Assert.AreEqual(OrderStatus.SUCCESS, authorizationResponse.paymentStatus);
        }

        /// <summary>
        /// Vefiy that authorise APM Order works
        /// </summary>
        [Ignore]
        [TestMethod]
        public void ShouldAuthoriseAPMOrder()
        {
            //We need to amend the simulator to auto submit the form and send notifications automatically in order to unit test this
        }

        /// <summary>
        /// Verify that refunding the order works
        /// </summary>
        [TestMethod]
        public void ShouldRefundOrder()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();

            string orderCode = _orderService.Create(orderRequest).orderCode;
            Assert.IsNotNull(orderCode);

            _orderService.Refund(orderCode);
        }

        [TestMethod]
        public void ShouldGetExistingOrder()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();
            string orderCode = _orderService.Create(orderRequest).orderCode;

            TransferOrder order = _orderService.FindOrder(orderCode);

            Assert.AreEqual(orderCode, order.orderCode);
        }

        [TestMethod]
        public void ShouldPartiallyRefundOrder()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = CreateToken();

            string orderCode = _orderService.Create(orderRequest).orderCode;
            Assert.IsNotNull(orderCode);

            _orderService.Refund(orderCode, 500);
        }

        /// <summary>
        /// Verify that an exception is thrown when creating an order with an invalid token
        /// </summary>
        [TestMethod]
        public void ShouldThrowExceptionForInvalidToken()
        {
            OrderRequest orderRequest = createOrderRequest();
            orderRequest.token = "invalid-token";

            try
            {
                _orderService.Create(orderRequest);
            }
            catch (WorldpayException e)
            {
                Assert.AreEqual("TKN_NOT_FOUND", e.apiError.customCode);
            }
        }

        private string CreateToken()
        {
            return TestHelpers.CreateToken(_authService);
        }

        private string CreateAPMToken()
        {
            return TestHelpers.CreateAPMToken(_authService);
        }

        /// <summary>
        /// Create an order request
        /// </summary>
        private OrderRequest createOrderRequest()
        {
            var orderRequest = new OrderRequest();
            orderRequest.amount = 1999;
            orderRequest.currencyCode = CurrencyCode.GBP.ToString();
            orderRequest.name = "test name";
            orderRequest.orderDescription = "test description";

            var address = new Address();
            address.address1 = "line 1";
            address.address2 = "line 2";
            address.city = "city";
            address.countryCode = CountryCode.GB.ToString();
            address.postalCode = "AB1 2CD";
            orderRequest.billingAddress = address;

            var customerIdentifiers = new Dictionary<string, string>();
            customerIdentifiers["test key 1"] = "test value 1";

            orderRequest.customerIdentifiers = customerIdentifiers;
            return orderRequest;
        }

        /// <summary>
        /// Create a 3DS order request
        /// </summary>
        private OrderRequest create3DSOrderRequest()
        {
            var orderRequest = new OrderRequest();
            orderRequest.amount = 1999;
            orderRequest.currencyCode = CurrencyCode.GBP.ToString();
            orderRequest.name = "3D";
            orderRequest.orderDescription = "test description";

            var threeDSInfo = new ThreeDSecureInfo();
            threeDSInfo.shopperIpAddress = "127.0.0.1";
            threeDSInfo.shopperSessionId = "sessionId";
            threeDSInfo.shopperUserAgent = "Mozilla/v1";
            threeDSInfo.shopperAcceptHeader = "application/json";
            orderRequest.threeDSecureInfo = threeDSInfo;
            orderRequest.is3DSOrder = true;

            var address = new Address();
            address.address1 = "line 1";
            address.address2 = "line 2";
            address.city = "city";
            address.countryCode = CountryCode.GB.ToString();
            address.postalCode = "AB1 2CD";
            orderRequest.billingAddress = address;

            var customerIdentifiers = new Dictionary<string, string>();
            customerIdentifiers["test key 1"] = "test value 1";

            orderRequest.customerIdentifiers = customerIdentifiers;
            return orderRequest;
        }

        /// <summary>
        /// Create a APM order request
        /// </summary>
        private OrderRequest createAPMOrderRequest()
        {
            var orderRequest = new OrderRequest();
            orderRequest.amount = 1999;
            orderRequest.successUrl = "http://www.testurl.com/success";
            orderRequest.cancelUrl = "http://www.testurl.com/cancel";
            orderRequest.failureUrl = "http://www.testurl.com/failure";
            orderRequest.pendingUrl = "http://www.testurl.com/pending";

            orderRequest.currencyCode = CurrencyCode.GBP.ToString();
            orderRequest.name = "Test";
            orderRequest.orderDescription = "test description";
            orderRequest.is3DSOrder = false;

            var address = new Address();
            address.address1 = "line 1";
            address.address2 = "line 2";
            address.city = "city";
            address.countryCode = CountryCode.GB.ToString();
            address.postalCode = "AB1 2CD";
            orderRequest.billingAddress = address;

            var customerIdentifiers = new Dictionary<string, string>();
            customerIdentifiers["test key 1"] = "test value 1";

            orderRequest.customerIdentifiers = customerIdentifiers;
            return orderRequest;
        }
    }
}