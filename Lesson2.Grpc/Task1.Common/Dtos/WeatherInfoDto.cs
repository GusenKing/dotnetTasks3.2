namespace Task1.Common.Dtos;

public class WeatherInfoDto
{
    public float Temperature { get; set; }

    public string? TemperatureUnit { get; set; }

    public DateTimeOffset Time { get; set; }
}