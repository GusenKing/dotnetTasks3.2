using Lesson9.Backend.Contracts;
using MassTransit;

namespace Lesson9.Backend.Services.BackgroundServices;

public class UpdatePublisher(ILogger<UpdatePublisher> logger, IBus bus) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = "Hello at " + DateTime.UtcNow;
            await bus.Publish(new UpdateMessage(message), stoppingToken);
            logger.LogInformation("Published {message}", message);
            await Task.Delay(1000, stoppingToken);
        }
    }
}