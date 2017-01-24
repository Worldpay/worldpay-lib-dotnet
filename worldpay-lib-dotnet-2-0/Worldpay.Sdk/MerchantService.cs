using System;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    public class MerchantService : AbstractService
    {
        private readonly string _baseUrl;

        /// <summary>
        /// Constructor
        /// </summary>
        public MerchantService(string baseUrl, Http http) : base(http)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchant"></param>
        public void Create(BaseMerchant merchant)
        {
            Http.Post(String.Format("{0}/merchants", _baseUrl), merchant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantId"></param>
        public Merchant Get(string merchantId)
        {
            return Http.Get<Merchant>(String.Format("{0}/merchants/{1}", _baseUrl, merchantId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="merchant"></param>
        public void Update(string merchantId, Merchant merchant)
        {
            Http.Post(String.Format("{0}/merchants/{1}", _baseUrl, merchantId), merchant);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="merchant"></param>
        public void Put(string merchantId, Merchant merchant)
        {
            Http.Post(String.Format("{0}/merchants/{1}", _baseUrl, merchantId), merchant);
        }

    }
}
