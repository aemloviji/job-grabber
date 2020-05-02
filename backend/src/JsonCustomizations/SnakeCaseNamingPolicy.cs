using System.Linq;
using System.Text.Json;

namespace JobGrabber.Backend.JsonCustomizations
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return ToSnakeCase(name);
        }

        private string ToSnakeCase(string name)
        {
            var normilizedChars = name
                .Select((@char, indx) =>
                    indx > 0 && char.IsUpper(@char)
                    ? "_" + @char.ToString().ToLower()
                    : @char.ToString().ToLower());

            return string.Concat(normilizedChars).ToLower();
        }
    }
}
