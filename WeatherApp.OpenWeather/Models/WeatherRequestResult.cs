using System.Text.Json.Serialization;

namespace WeatherApp.OpenWeather.Models
{
    internal class WeatherRequestResult
    {
        [JsonPropertyName("weather")]
        public IEnumerable<WeatherResponse> Weather { get; set; }

        [JsonPropertyName("main")]
        public MainResponse Main { get; set; }

        [JsonPropertyName("coord")]
        public CoordinatesResponse Coordinates { get; set; }
    }
}
