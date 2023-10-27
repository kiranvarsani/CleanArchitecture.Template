using Application.Common;
using Domain;
using Infrastructure.Data;
using Infrastructure.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastRepository, WeatherForecastForecastRepository>();
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("WeatherSystem"));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}