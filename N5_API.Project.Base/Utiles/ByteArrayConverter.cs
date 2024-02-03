using System;
using Newtonsoft.Json;

namespace N5_API.Project.Base.Utiles
{


    /// <summary>
    /// Utility class for for Timestamp treatment
    /// </summary>
    public class ByteArrayConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(TimestampUtils.TimestampToString((byte[])value));

        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            if (reader != null)
            {
                if (reader.Value != null)
                {
                    return TimestampUtils.StringToTimestamp(reader.Value.ToString());
                }

            }

            return reader;

        }

        public override bool CanConvert(Type objectType) => objectType == typeof(byte[]);
    }
}
