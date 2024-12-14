using WeatherApp.MSSQLSearchHistoryStorage.EF;
using WeatherApp.Shared.SearchHistoryStorage;
using WeatherApp.Shared.SearchHistoryStorage.Interfaces;
using WeatherApp.Shared.WeatherDataProviders;

namespace WeatherApp.MSSQLSearchHistoryStorage
{
    public class MSSQLSearchHistoryStorage : ISearchHistoryStorage
    {
        private readonly SearchHistoryContext _db;

        public MSSQLSearchHistoryStorage(SearchHistoryContext db)
        {
            _db = db;
        }

        public void Save(string userSessionId, string city, WeatherData weather)
        {
            weather.Id = Guid.NewGuid();

            var searchRequest = new SearchRequest()
            {
                Id = Guid.NewGuid(),
                UserSessionId = userSessionId,
                City = city,
                WeatherData = weather,
                DateTime = DateTime.Now,
            };

            _db.SearchRequests.Add(searchRequest);
            _db.SaveChanges();
        }

        public IEnumerable<SearchRequest> GetHistory(string userSessionId)
        {
            return _db.SearchRequests.Where(x => x.UserSessionId == userSessionId).ToList();
        }
    }
}
