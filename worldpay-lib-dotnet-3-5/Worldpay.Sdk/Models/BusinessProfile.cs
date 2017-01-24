namespace Worldpay.Sdk.Models
{
    public class BusinessProfile
    {
        public string descriptionOfYourGoodsAndServices { get; set; }

        public int anticipatedAverageMonthlyTurnover { get; set; }

        public int anticipatedPeakMonthlyTurnover { get; set; }

        public int daysFromOrderConfirmationToDelivery { get; set; }

        public bool depositInAdvance { get; set; }

        public int percentageOfTotalTurnoverToRelatedBusiness { get; set; }

        public int percentageOfTotalTurnoverTakenAsDeposit { get; set; }

        public int averageDaysBetweenDepositAndFullPayment { get; set; }

        public int averageDaysBetweenFullPaymentAndDelivery { get; set; }

        public int averageDaysInHolidayDuration { get; set; }

        public bool doYouOfferSubscriptionMembershipServices { get; set; }

        public int averageSubscriptionLengthInMonths { get; set; }

        public int percentageOfTotalTurnoverToSubscriptionBusiness { get; set; }

        public int anticipatedTotalTurnoverForSubscription { get; set; }
    }
}
