using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Worldpay.Sdk.Models
{
    [DataContract, Serializable]
    public class TransferResponse
    {
        [DataMember]
        public List<TransferSummary> transfers { get; set; }

        [DataMember]
        public int totalPages { get; set; }

        [DataMember]
        public int numberOfElements { get; set; }

        [DataMember]
        public int currentPageNumber { get; set; }
    }
}
