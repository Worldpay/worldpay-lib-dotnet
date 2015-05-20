using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Worldpay.Sdk.Test
{
    [TestClass]
    public class TransferServiceTest
    {
        private TransferService _transferService;

        [TestInitialize]
        public void Setup()
        {
            var restClient = new WorldpayRestClient(Configuration.ServiceKey);
            _transferService = restClient.GetTransferService();
        }

        [TestMethod]
        public void TestGetTransfers()
        {
            var response = _transferService.GetTransfers(Configuration.MerchantId, null);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestGetTransfer()
        {
            var response = _transferService.GetTransfer(Configuration.MerchantId);
            Assert.IsNotNull(response);
        }
    }
}
