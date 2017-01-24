using System;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class TransferDetail
    {
        public string transferId { get; set; }

        public TransferOrder orders { get; set; }
    }
}
