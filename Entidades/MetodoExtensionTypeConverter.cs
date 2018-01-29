using System;
using Newtonsoft.Json;

namespace Entidades
{
    public sealed class MetodoExtensionTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            switch (value)
            {
                case "ReadInt":
                    return MetodoExtension.ReadInt;
                case "ReadFullInt":
                    return MetodoExtension.ReadFullInt;
                case "ReadString":
                    return MetodoExtension.ReadString;
                case "ReadFullString":
                    return MetodoExtension.ReadFullString;
                case "ReadDateString":
                    return MetodoExtension.ReadDateString;
                case "ReadDateTime":
                    return MetodoExtension.ReadDateTime;
                default:
                    return MetodoExtension.Read;
            }
        }

        public override void WriteJson(JsonWriter writer, object Value, JsonSerializer serializer)
        {
            var value = (MetodoExtension)Value;
            writer.WriteValue("snake_case");

            switch (value)
            {
                case MetodoExtension.ReadInt:
                    writer.WriteValue("ReadInt");
                    break;
                case MetodoExtension.ReadFullInt:
                    writer.WriteValue("ReadFullInt");
                    break;
                case MetodoExtension.ReadString:
                    writer.WriteValue("ReadString");
                    break;
                case MetodoExtension.ReadFullString:
                    writer.WriteValue("ReadFullString");
                    break;
                case MetodoExtension.ReadDateString:
                    writer.WriteValue("ReadDateString");
                    break;
                case MetodoExtension.ReadDateTime:
                    writer.WriteValue("ReadDateTime");
                    break;
            }
        }
    }
}