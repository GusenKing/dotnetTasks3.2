using System.Text.Json.Serialization;

namespace Task1.Server.Dtos;

public class WeatherForSpecificTimeDto
{
    [JsonPropertyName("hourly")] public Hourly? Hourly { get; set; }

    [JsonPropertyName("hourly_units")] public HourlyUnits? HourlyUnits { get; set; }
}

public class Hourly
{
    public string?[] Time { get; set; }


    [JsonPropertyName("temperature_2m")] public float[] Temperature { get; set; }
}

public class HourlyUnits
{
    [JsonPropertyName("temperature_2m")] public string?[] Temperature { get; set; }
}