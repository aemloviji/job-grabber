using System.Linq;
using System.Text.Json;
using JobGrabber.Backend.JsonCustomizations.Convertors;

namespace JobGrabber.Backend.JsonCustomizations
{
    public class JsonSerializerWrapper
    {
        private static JsonSerializerOptions _jsonSerializerOptions;

        static JsonSerializerWrapper()
        {
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseNamingPolicy() };
            _jsonSerializerOptions.Converters.Add(new DateTimeOffsetConverter());
        }

        public static T Deserialize<T>(string data) =>
                JsonSerializer.Deserialize<T>(data, _jsonSerializerOptions);
    }
}
