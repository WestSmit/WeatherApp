

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherApp.OpenWeather.Models
{
    internal class CityLocation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lat")]
        public float Latitude { get; set; }

        [JsonPropertyName("lon")]
        public float Longitude { get; set; }
    }
}
