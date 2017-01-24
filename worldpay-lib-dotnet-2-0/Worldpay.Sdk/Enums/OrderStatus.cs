namespace Worldpay.Sdk.Enums
{
    public enum OrderStatus
    {
        SUCCESS,
        FAILED,
        AUTHORIZED,
        PRE_AUTHORIZED,
        SENT_FOR_REFUND,
        PARTIALLY_REFUNDED,
        REFUNDED,
        SETTLED,
        INFORMATION_REQUESTED,
        INFORMATION_SUPPLIED,
        CHARGED_BACK,
        EXPIRED,
        CHARGEBACK_REVERSED
    }
}