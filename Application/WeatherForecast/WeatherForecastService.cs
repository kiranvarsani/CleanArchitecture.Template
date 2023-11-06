using Domain;

namespace Application.WeatherForecast;

public sealed class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository, IUnitOfWork unitOfWork)
    {
        _weatherForecastRepository = weatherForecastRepository;
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<WeatherForecastResponse> GetAllWeatherForecasts()
    {
        List<WeatherForecastResponse> weatherForecastResponses = new List<WeatherForecastResponse>();
        var forecastList = _weatherForecastRepository.GetAll();
        foreach (var weatherForecast in forecastList)
        {
            weatherForecastResponses.Add(new WeatherForecastResponse
            {
                Id = weatherForecast.Id ?? 0,
                Date = weatherForecast.Date,
                Summary = weatherForecast.Summary,
                TemperatureC = weatherForecast.TemperatureC
            });
        }

        return weatherForecastResponses;
    }

    public WeatherForecastResponse GetWeatherForecastById(int weatherForecastId)
    {
        var entity = _weatherForecastRepository.Get(weatherForecastId);
        return new WeatherForecastResponse(entity);
    }
    public WeatherForecastResponse AddWeatherForecast(DateOnly date, int temperatureC, string? summary)
    {
        // business to add a new entity goes here
        var weatherForecast = new WeatherForecastEntity(date, temperatureC, summary);
        _weatherForecastRepository.Add(weatherForecast);
        _unitOfWork.SaveChangesAsync();
        return new WeatherForecastResponse(weatherForecast);
    }
    
    public WeatherForecastResponse UpdateWeatherForecast(int weatherForecastId, DateOnly date, int temperatureC, string? summary)
    {
        // business to update an existing entity goes here
        var weatherForecast = _weatherForecastRepository.Get(weatherForecastId);
        weatherForecast.Date = date;
        weatherForecast.TemperatureC = temperatureC;
        weatherForecast.Summary = summary;
        
        _weatherForecastRepository.Update(weatherForecast);
        _unitOfWork.SaveChangesAsync();
        return new WeatherForecastResponse(weatherForecast);
    }
    
    public IEnumerable<WeatherForecastResponse> DeleteWeatherForecast(int weatherForecastId)
    {
        // business to delete an existing entity goes here
        _weatherForecastRepository.Delete(weatherForecastId);
        _unitOfWork.SaveChangesAsync();
        var dataset = _weatherForecastRepository.GetAll();
        return dataset.Select(entity => new WeatherForecastResponse(entity)).ToList();
    }
}