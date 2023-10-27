using System.ComponentModel.DataAnnotations;

namespace Domain;

public class WeatherForecastEntity
{
    public WeatherForecastEntity(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    [Key]
    public int Id { get; set; }
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
