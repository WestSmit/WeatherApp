using System.Text.Json.Serialization;

namespace WeatherApp.OpenWeather.Models
{
    internal class MainResponse
    {
        [JsonPropertyName("temp")]
        public float Temperature { get; set; }        
        
        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("humidity")]
        public float Humidity { get; set; }       
        
        [JsonPropertyName("pressure")]
        public float Pressure { get; set; }
    }
}
