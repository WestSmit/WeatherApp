using Microsoft.EntityFrameworkCore;
using WeatherApp.Shared.SearchHistoryStorage;
using WeatherApp.Shared.WeatherDataProviders;

namespace WeatherApp.MSSQLSearchHistoryStorage.EF
{
    public class SearchHistoryContext : DbContext
    {
        public virtual DbSet<SearchRequest> SearchRequests { get; set; }

        public virtual DbSet<WeatherData> WeatherData { get; set; }

        public SearchHistoryContext(DbContextOptions<SearchHistoryContext> options) : base(options) {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SearchRequest>(searchRequest =>
            {
                searchRequest.HasKey(x => x.Id);
            });

            builder.Entity<WeatherData>(weatherData =>
            {
                weatherData.HasKey(x => x.Id);
            });
        }
    }
}
