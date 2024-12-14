using WeatherApp.Shared.WeatherDataProviders;

namespace WeatherApp.Shared.SearchHistoryStorage
{
    public class SearchRequest
    {
        public Guid Id { get; set; }

        public string UserSessionId { get; set; }

        public DateTime DateTime { get; set; }

        public string City { get; set; }

        public WeatherData WeatherData { get; set; }

    }
}
