namespace Application.WeatherForecast;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecastResponse> GetAllWeatherForecasts();
    WeatherForecastResponse GetWeatherForecastById(int weatherForecastId);
    WeatherForecastResponse AddWeatherForecast(DateOnly date, int temperatureC, string? summary);
    WeatherForecastResponse UpdateWeatherForecast(int weatherForecastId, DateOnly date, int temperatureC, string? summary);
    IEnumerable<WeatherForecastResponse> DeleteWeatherForecast(int weatherForecastId);
}