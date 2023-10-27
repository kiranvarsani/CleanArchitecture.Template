namespace Application.WeatherForecast;

public class UpdateWeatherForecastCommand
{
    public int WeatherForecastId { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}