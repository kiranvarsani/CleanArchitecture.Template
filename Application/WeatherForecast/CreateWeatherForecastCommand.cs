namespace Application.WeatherForecast;

public class CreateWeatherForecastCommand
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}