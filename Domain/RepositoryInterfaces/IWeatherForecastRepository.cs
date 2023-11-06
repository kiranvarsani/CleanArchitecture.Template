namespace Domain;

public interface IWeatherForecastRepository
{
    IEnumerable<WeatherForecastEntity> GetAll();
    WeatherForecastEntity Get(int weatherForecastId);
    void Add(WeatherForecastEntity weatherForecast);
    void Update(WeatherForecastEntity weatherForecast);
    void Delete(int weatherForecastId);
}