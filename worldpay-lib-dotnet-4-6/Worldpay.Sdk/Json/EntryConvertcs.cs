using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk.Json
{
    public class EntryConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = value as List<Entry>;
            if (list == null) return;

            writer.WriteStartObject();
            foreach (var item in list)
            {
                writer.WritePropertyName(item.key);
                writer.WriteValue(item.value);
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            return jsonObject.Properties().Select(property => new Entry(property.Name, Convert.ToString(property.Value))).ToList();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Entry>);
        }
    }
}
