using Application.Common;
using Domain;

namespace Infrastructure.WeatherForecast;

public sealed class WeatherForecastForecastRepository : IWeatherForecastRepository
{
    private readonly IApplicationDbContext _applicationDbContext;
    public WeatherForecastForecastRepository(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public IEnumerable<WeatherForecastEntity> GetAll()
    {
        return _applicationDbContext.WeatherForecasts.ToArray();
    }

    public WeatherForecastEntity Get(int weatherForecastId)
    {
        if (weatherForecastId < 1)
            throw new ArgumentException($"Invalid argument {nameof(weatherForecastId)}");
        
        return _applicationDbContext.WeatherForecasts.Find(weatherForecastId) ?? throw new KeyNotFoundException($"Weather forecast with the Id {weatherForecastId} not found");
    }

    public void Add(WeatherForecastEntity weatherForecast)
    {
        _applicationDbContext.WeatherForecasts.Add(weatherForecast);
    }

    public void Update(WeatherForecastEntity weatherForecast)
    {
        _applicationDbContext.WeatherForecasts.Update(weatherForecast);
    }

    public void Delete(int weatherForecastId)
    {
        var weatherForecast = _applicationDbContext.WeatherForecasts.Find(weatherForecastId);
        if (weatherForecast == null)
            throw new KeyNotFoundException($"Weather forecast with the Id {weatherForecastId} not found"); 
        
        _applicationDbContext.WeatherForecasts.Remove(weatherForecast);
    }
}