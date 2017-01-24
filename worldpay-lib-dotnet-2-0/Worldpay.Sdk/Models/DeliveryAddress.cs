using System;
using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    [Serializable]
    public class DeliveryAddress : Address
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

    }
}
