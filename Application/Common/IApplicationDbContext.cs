using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public interface IApplicationDbContext
{
    DbSet<Domain.WeatherForecastEntity> WeatherForecasts { get; }
}