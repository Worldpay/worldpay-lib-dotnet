using Worldpay.Sdk.Enums;

namespace Worldpay.Sdk.Models
{
    class PersonRecord : AbstractPerson
    {
        public int dayOfBirth { get; set; }

        public int monthOfBirth { get; set; }

        public int yearOfBirth { get; set; }

        public int ownershipPercentage { get; set; }

        public Address homeAddress { get; set; }

        public CountryCode nationality { get; set; }
    }
}
