using System.Text.Json.Serialization;

namespace Ginilytics.Api.Startup.Configuration
{
    public class AppConfiguration
    {

        [JsonPropertyName("AllowedHosts")]
        public string AllowedHosts { get; set; }
    }
}