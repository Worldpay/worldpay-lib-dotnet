namespace Worldpay.Sdk.Models
{
    public class Merchant : BaseMerchant
    {
        public MerchantOrderSetting orderSetting { get; set; }

        public PersonContact mainBusinessRepresentative { get; set; }

        public Company companyDetail { get; set; }

        public Account bankDetail { get; set; }

        public string statementNarrative { get; set; }

        public PersonContact technicalContact { get; set; }

        public BusinessProfile BusinessProfile { get; set; }

        public string priceCode { get; set; }

        public string shoppingCardUsed { get; set; }
    }
}
