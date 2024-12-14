using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using WeatherApp.MSSQLSearchHistoryStorage;
using WeatherApp.MSSQLSearchHistoryStorage.EF;
using WeatherApp.OpenWeather;
using WeatherApp.Shared.SearchHistoryStorage.Interfaces;
using WeatherApp.Shared.WeatherDataProviders.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherDataProvider, OpenWeatherDataProvider>();
builder.Services.AddScoped<ISearchHistoryStorage, MSSQLSearchHistoryStorage>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SearchHistoryContext>(x =>
{
    x.UseSqlServer(connectionString);
});

builder.Services.AddMemoryCache();

builder.Services
    .AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
    })
   .AddMvc(options => { })
   .AddApiExplorer(options =>
   {
       options.GroupNameFormat = "'v'VVV";
       options.SubstituteApiVersionInUrl = true;
   });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();

        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(new ExceptionHandlerOptions()
{
    AllowStatusCode404Response = true,
    ExceptionHandlingPath = "/error"
});

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
