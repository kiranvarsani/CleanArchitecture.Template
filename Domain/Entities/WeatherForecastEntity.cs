using System.ComponentModel.DataAnnotations;
using Domain.Primitives;

namespace Domain;

public sealed class WeatherForecastEntity : Entity
{
    public WeatherForecastEntity(DateOnly date, int temperatureC, string? summary): base(null)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
    public WeatherForecastEntity(int? id, DateOnly date, int temperatureC, string? summary) : base(id)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
    
    public DateOnly Date { get; set; }
    
    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
