namespace WeatherApp.Shared.WeatherDataProviders.Interfaces
{
    public interface IWeatherDataProvider
    {
        public Task<WeatherData> GetWeather(string city);
    }
}
