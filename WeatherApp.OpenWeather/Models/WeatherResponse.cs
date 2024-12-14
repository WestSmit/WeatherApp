using System.Text.Json.Serialization;

namespace WeatherApp.OpenWeather.Models
{
    internal class WeatherResponse
    {
        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
