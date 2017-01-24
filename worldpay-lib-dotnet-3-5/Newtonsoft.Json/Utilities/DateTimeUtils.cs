using System;
using System.Xml;

namespace Newtonsoft.Json.Utilities
{
    internal static class DateTimeUtils
    {
        public static XmlDateTimeSerializationMode ToSerializationMode(DateTimeKind kind)
        {
            switch (kind)
            {
                case DateTimeKind.Local:
                    return XmlDateTimeSerializationMode.Local;
                case DateTimeKind.Unspecified:
                    return XmlDateTimeSerializationMode.Unspecified;
                case DateTimeKind.Utc:
                    return XmlDateTimeSerializationMode.Utc;
                default:
                    throw new ArgumentOutOfRangeException("kind", kind, "Unexpected DateTimeKind value.");
            }
        }
    }
}
