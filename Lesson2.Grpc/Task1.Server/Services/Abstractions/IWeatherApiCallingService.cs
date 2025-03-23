using Task1.Common.Dtos;

namespace Task1.Server.Services.Abstractions;

public interface IWeatherApiCallingService
{
    public Task<WeatherInfoDto?> GetWeatherForecastAsync();
}