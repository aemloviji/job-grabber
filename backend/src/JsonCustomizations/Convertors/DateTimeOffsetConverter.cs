using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JobGrabber.Backend.JsonCustomizations.Convertors
{
    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        // https://docs.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo?view=netcore-3.1#examples
        private const string RFC1123Pattern = "ddd MMM dd HH:mm:ss UTC yyyy";

        public override DateTimeOffset Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
             DateTimeOffset.ParseExact(reader.GetString(),
                            RFC1123Pattern, CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTimeOffset dateTimeValue,
            JsonSerializerOptions options) =>
                throw new NotImplementedException("We don't do any serialization yet.");
    }
}