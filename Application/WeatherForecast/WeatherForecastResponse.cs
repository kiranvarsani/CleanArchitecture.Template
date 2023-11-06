using Domain;

namespace Application.WeatherForecast;

public record WeatherForecastResponse
{
    public WeatherForecastResponse()
    {
    }

    public WeatherForecastResponse(WeatherForecastEntity weatherForecastEntity)
    {
        Id = weatherForecastEntity.Id ?? 0;
        Date = weatherForecastEntity.Date;
        TemperatureC = weatherForecastEntity.TemperatureC;
        Summary = weatherForecastEntity.Summary;
    }

    public int Id { get; set; }
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}