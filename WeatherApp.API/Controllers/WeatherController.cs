using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using WeatherApp.Shared.SearchHistoryStorage;
using WeatherApp.Shared.SearchHistoryStorage.Interfaces;
using WeatherApp.Shared.WeatherDataProviders;
using WeatherApp.Shared.WeatherDataProviders.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WeatherApp.API.Controllers
{
    [ApiController]
    [Route("api/{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        private readonly IWeatherDataProvider _weather;

        private readonly IMemoryCache _cache;

        private readonly ISearchHistoryStorage _searchHistoryStorage;

        public WeatherController(
            ILogger<WeatherController> logger,
            IWeatherDataProvider weather,
            IMemoryCache cache,
            ISearchHistoryStorage searchHistoryStorage)
        {
            _logger = logger;
            _weather = weather;
            _cache = cache;
            _searchHistoryStorage = searchHistoryStorage;
        }

        [HttpGet]
        [Route("search/{city}")]
        public async Task<IActionResult> Search(string city)
        {
            var clientIp = HttpContext.Connection.RemoteIpAddress;

            var cacheData = _cache.Get<WeatherData>(city);
            if (cacheData != null)
            {
                Console.WriteLine("Data loaded from cache");

                _searchHistoryStorage.Save(clientIp.ToString(), city, cacheData);

                return Ok(cacheData);
            }

            var resultFromProvider = await _weather.GetWeather(city);

            _cache.Set(city, resultFromProvider, TimeSpan.FromMinutes(30));

            _searchHistoryStorage.Save(clientIp.ToString(), city, resultFromProvider);

            return Ok(resultFromProvider);
        }

        [HttpGet]
        [Route("history")]
        public IActionResult GetHistory()
        {
            var clientIp = HttpContext.Connection.RemoteIpAddress;

            return Ok(_searchHistoryStorage.GetHistory(clientIp.ToString()));
        }

        [Route("/error")]
        protected IActionResult HandleError() =>
            Problem();
        }
}
