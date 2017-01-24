using System;
using System.Collections.Generic;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class TransferResponse
    {
        public List<TransferSummary> transfers { get; set; }

        public int totalPages { get; set; }

        public int numberOfElements { get; set; }

        public int currentPageNumber { get; set; }
    }
}
