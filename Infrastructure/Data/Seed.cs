using Domain;

namespace Infrastructure.Data;

public static class Seed
{
    public static void Run(ApplicationDbContext? dbContext)
    {
        dbContext.Database.EnsureCreated();
        if (!dbContext.WeatherForecasts.Any())
        {
            List<WeatherForecastEntity> entities = new List<WeatherForecastEntity>();
            entities.Add(
                new WeatherForecastEntity(1, DateOnly.Parse("2021-01-01"), -40, "Freezing cold"));
            entities.Add(new WeatherForecastEntity(2, DateOnly.Parse("2022-02-02"), 0, "Fridge cold"));
            entities.Add(new WeatherForecastEntity(3, DateOnly.Parse("2023-03-03"), 30, "Melting cold"));
            entities.Add(new WeatherForecastEntity(4, DateOnly.Parse("2024-04-04"), 50, "Burning Hot"));
            
            dbContext.AddRange(entities);
            dbContext.SaveChanges();
        }
    }
}