using System.Text.Json.Serialization;

namespace WeatherApp.Shared.WeatherDataProviders
{
    public class WeatherData
    {
        public Guid Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public float Temperature { get; set; }

        public float FeelsLike { get; set; }

        public float Humidity { get; set; }

        public float Pressure { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
