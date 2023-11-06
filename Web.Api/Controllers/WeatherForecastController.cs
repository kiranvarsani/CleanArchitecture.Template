using Application.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "WeatherForecast")]
    public IEnumerable<WeatherForecastResponse> GetAll()
    {
        _logger.LogInformation("Fetching Random Weather Forecast...");
        return _weatherService.GetAllWeatherForecasts();
    }
    
    // [HttpGet(Name = "WeatherForecasts/{weatherForecastId}")]
    // public ActionResult<WeatherForecastResponse> Get(int weatherForecastId)
    // {
    //     _logger.LogInformation("Fetching Random Weather Forecast...");
    //     return _weatherService.GetWeatherForecastById(weatherForecastId);
    // }
    
    [HttpPost(Name = "WeatherForecast")]
    public ActionResult<WeatherForecastResponse> Add(CreateWeatherForecastCommand command)
    {
        _logger.LogInformation("Adding Weather Forecast...");
        return CreatedAtAction(nameof(Add), _weatherService.AddWeatherForecast(command.Date, command.TemperatureC, command.Summary));
    }
    
    [HttpPut(Name = "WeatherForecast")]
    public WeatherForecastResponse Update([FromBody]UpdateWeatherForecastCommand command)
    {
        _logger.LogInformation("Updating Weather Forecast...");
        return _weatherService.UpdateWeatherForecast(command.Id, command.Date, command.TemperatureC, command.Summary);
    }
    
    [HttpDelete(Name = "WeatherForecast")]
    public IEnumerable<WeatherForecastResponse> Delete([FromBody]DeleteWeatherForecastCommand command)
    {
        _logger.LogInformation("Deleting Weather Forecast...");
        return _weatherService.DeleteWeatherForecast(command.Id);
    }
}
