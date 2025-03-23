using System.Text.Json;
using Task1.Common.Dtos;
using Task1.Server.Dtos;
using Task1.Server.Services.Abstractions;

namespace Task1.Server.Services;

public class OpenMeteoApiCallingService(ILogger<OpenMeteoApiCallingService> logger) : IWeatherApiCallingService
{
    private const double KazanLatitude = 55.47;
    private const double KazanLongitude = 49.07;

    private readonly string _currentWeatherApiUrl =
        "https://api.open-meteo.com/v1/forecast?current=temperature_2m&timezone=Europe/Moscow";

    private readonly HttpController _httpController = new();

    public async Task<WeatherInfoDto?> GetWeatherForecastAsync()
    {
        try
        {
            var response =
                await _httpController.Client.GetAsync(
                    $"{_currentWeatherApiUrl}&latitude={KazanLatitude}&longitude={KazanLongitude}");
            response.EnsureSuccessStatusCode();

            var weatherForecast = await JsonSerializer.DeserializeAsync<WeatherForSpecificTimeDto>(
                await response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var necessaryWeatherInfo = new WeatherInfoDto
            {
                Temperature = weatherForecast?.Current?.Temperature,
                TemperatureUnit = weatherForecast?.CurrentUnits?.Temperature, Time = weatherForecast?.Current?.Time
            };

            return necessaryWeatherInfo;
        }
        catch (HttpRequestException e)
        {
            logger.LogError(e.Message);
            return null;
        }
    }
}