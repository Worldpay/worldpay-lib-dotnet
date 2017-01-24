using System;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    /// <summary>
    /// 
    /// </summary>
    public class TransferService : AbstractService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// Constructor
        /// </summary>
        public TransferService(string baseUrl, Http http)
            : base(http)
        {
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TransferResponse GetTransfers(string merchantId, int? pageNumber)
        {
            var url = String.Format("{0}/transfers?merchantId={1}&pageNumber={2}", _baseUrl, merchantId, pageNumber);
            return Http.Get<TransferResponse>(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferId"></param>
        public TransferResponse GetTransfer(string transferId)
        {
            var url = String.Format("{0}/transfers", transferId);
            return Http.Get<TransferResponse>(url);
        }
    }
}
