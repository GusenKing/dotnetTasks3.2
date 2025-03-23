using Grpc.Core;
using Lesson2.Grpc;

namespace Task1.Server.Services;

public class WeatherStreamingService : WeatherService.WeatherServiceBase
{
    public override async Task StreamingFromServer(WeatherStreamRequest request,
        IServerStreamWriter<WeatherStreamResponse> responseStream, ServerCallContext context)
    {
        var timeOffset = new DateTimeOffset();

        while (!context.CancellationToken.IsCancellationRequested)
            await responseStream.WriteAsync(new ExampleResponse());
        await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
    }
}