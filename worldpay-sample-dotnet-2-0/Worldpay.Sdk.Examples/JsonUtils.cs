using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace Worldpay.Sdk.Examples
{
    /// <summary>
    /// Utilities recreating functionality available in Newtonsoft.Json for .NET 3.5
    /// </summary>
    public static class JsonUtils
    {
        /// <summary>
        /// Serialize an object to JSON using pretty-print to make the response human-readable
        /// </summary>
        /// <param name="value">Object to serialize</param>
        /// <returns>JSON representing the object with indented formatting</returns>
        public static string SerializeObject(object value)
        {
            var sw = new StringWriter(CultureInfo.InvariantCulture);
            var jsonSerializer = new JsonSerializer();

            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonSerializer.Serialize(jsonWriter, value);
            }

            return sw.ToString();
        }
    }
}