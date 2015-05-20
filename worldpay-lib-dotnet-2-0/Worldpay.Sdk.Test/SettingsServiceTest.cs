using Microsoft.VisualStudio.TestTools.UnitTesting;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Test
{
    [TestClass]
    public class SettingsServiceTest
    {
        private SettingsService _settingsService;

        private const string MerchantId = "6406251b-f8f9-4355-91d9-085283e86ddd";

        [TestInitialize]
        public void Setup()
        {
            var restClient = new WorldpayRestClient(Configuration.ServiceKey);
            _settingsService = restClient.GetSettingsService();
        }

        [TestMethod]
        public void TestGetSettings()
        {
            SettingsResponse settings = _settingsService.GetSettings(MerchantId);
            
            Assert.IsNotNull(settings);
        }

        [TestMethod]
        public void TestUpdateBillingSettings()
        {
            _settingsService.UpdateRecurringBilling(MerchantId, true);
            
            SettingsResponse settings = _settingsService.GetSettings(MerchantId);            
            Assert.AreEqual(true, settings.orderSetting.optInForRecurringBilling);

            _settingsService.UpdateRecurringBilling(MerchantId, true);

            settings = _settingsService.GetSettings(MerchantId);
            Assert.AreEqual(false, settings.orderSetting.optInForRecurringBilling);
        }

        [TestMethod]
        public void TestUpdateRiskSettings()
        {
            var riskSetting = new RiskSetting()
            {
                avsEnabled = false,
                cvcEnabled = true
            };

            _settingsService.UpdateRiskSettings(MerchantId, riskSetting);

            var settings = _settingsService.GetSettings(MerchantId);
            Assert.AreEqual(false, settings.riskSetting.avsEnabled);
            Assert.AreEqual(true, settings.riskSetting.cvcEnabled);

            riskSetting = new RiskSetting()
            {
                avsEnabled = true,
                cvcEnabled = false
            };
            _settingsService.UpdateRiskSettings(MerchantId, riskSetting);

            settings = _settingsService.GetSettings(MerchantId);
            Assert.AreEqual(true, settings.riskSetting.avsEnabled);
            Assert.AreEqual(false, settings.riskSetting.cvcEnabled);
        }
    }
}

