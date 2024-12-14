using System.Net.Http.Json;
using WeatherApp.OpenWeather.Models;
using WeatherApp.Shared.WeatherDataProviders;
using WeatherApp.Shared.WeatherDataProviders.Interfaces;

namespace WeatherApp.OpenWeather
{
    public class OpenWeatherDataProvider : IWeatherDataProvider
    {
        private readonly HttpClient _client;
        private string _apiKey = "89a6ad4f18c57f30f40f295a7110d02d";

        public OpenWeatherDataProvider(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://api.openweathermap.org/");
        }

        public async Task<WeatherData> GetWeather(string city)
        {
            var location = await GetCityLocation(city);

            return await RequestWeatherData(location);
        }

        private async Task<CityLocation> GetCityLocation(string city)
        {
            var url = $"geo/1.0/direct?q={city}&limit=1&appid={_apiKey}";

            var locations = await _client.GetFromJsonAsync<IEnumerable<CityLocation>>(url);

            return locations.ToList().First();
        }

        private async Task<WeatherData> RequestWeatherData(CityLocation location)
        {
            var url = $"data/2.5/weather?lat={location.Latitude}&lon={location.Longitude}&appid={_apiKey}";

            var weatherResult = await _client.GetFromJsonAsync<WeatherRequestResult>(url);

            //[TO DO] Use Automapper
            return new WeatherData()
            {
                Main = weatherResult.Weather.First().Main,
                Description = weatherResult.Weather.First().Description,
                Icon = weatherResult.Weather.First().Icon,
                Temperature = weatherResult.Main.Temperature,
                FeelsLike = weatherResult.Main.FeelsLike,
                Humidity = weatherResult.Main.Humidity,
                Pressure = weatherResult.Main.Pressure,
                Longitude = weatherResult.Coordinates.Longitude,
                Latitude = weatherResult.Coordinates.Latitude,
            };
        }
    }
}
