using System.Text.Json.Serialization;

namespace WeatherApp.OpenWeather.Models
{
    internal class CoordinatesResponse
    {
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }

        [JsonPropertyName("lon")]
        public float Longitude { get; set; }
    }
}
