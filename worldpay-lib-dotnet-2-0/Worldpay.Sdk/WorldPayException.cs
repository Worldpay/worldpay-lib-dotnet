using System;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    /// <summary>
    /// Exception thrown when error returned by Worldpay API
    /// </summary>
    public class WorldpayException : Exception
    {
        /// <summary>
        /// Details of the API error
        /// </summary>
        public ApiError apiError { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public WorldpayException(string message) : this(null, message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WorldpayException(ApiError error, string message) : base(message)
        {
            apiError = error;
        }
    }
}
