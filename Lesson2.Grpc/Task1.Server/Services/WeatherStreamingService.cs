using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Lesson2.Grpc;
using Task1.Server.Services.Abstractions;

namespace Task1.Server.Services;

public class WeatherStreamingService(IWeatherApiCallingService weatherApiCallingService)
    : WeatherService.WeatherServiceBase
{
    public override async Task StreamingFromServer(WeatherStreamRequest request,
        IServerStreamWriter<WeatherStreamResponse> responseStream, ServerCallContext context)
    {
        var timeOffset = 0;
        var timeOfRequest = request.CurrentTime.ToDateTimeOffset();

        while (!context.CancellationToken.IsCancellationRequested)
        {
            var weatherResponse =
                await weatherApiCallingService.GetWeatherForecastAsync(timeOfRequest.AddHours(timeOffset));
            await responseStream.WriteAsync(new WeatherStreamResponse
            {
                Time = Timestamp.FromDateTimeOffset(weatherResponse.Time),
                WeatherUnits = weatherResponse.TemperatureUnit,
                WeatherValue = weatherResponse.Temperature
            });
            await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
            timeOffset += 2;
        }
    }
}