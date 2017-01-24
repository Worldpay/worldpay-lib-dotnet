namespace Worldpay.Sdk.Models
{
    public class Company
    {
        public string legalName { get; set; }

        public string tradingName { get; set; }

        public Address tradingAddress { get; set; }

        public Address legalAddress { get; set; }

        public string website { get; set; }

        public string companyType { get; set; }

        public string registrationNumber { get; set; }

        public string vatNumber { get; set; }

        public string incorporationMonth { get; set; }

        public string incorporationYear { get; set; }

        public string merchantCategoryPseudoName { get; set; }
    }
}
