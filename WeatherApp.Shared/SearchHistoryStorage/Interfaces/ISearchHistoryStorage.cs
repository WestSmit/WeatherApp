using WeatherApp.Shared.WeatherDataProviders;

namespace WeatherApp.Shared.SearchHistoryStorage.Interfaces
{
    public interface ISearchHistoryStorage
    {
        public void Save(string userSessionId, string city, WeatherData weather);

        public IEnumerable<SearchRequest> GetHistory(string userSessionId);
    }
}
