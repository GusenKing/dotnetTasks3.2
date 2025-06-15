using System.Globalization;

namespace Lesson14.KafkaProducer.Services;

public class PeriodicHostedService(
    IConfiguration configuration,
    IKafkaProducerService producerService)
    : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromSeconds(int.Parse(configuration["ProduceInterval"]!));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(_period);
        while (
            !stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
            for (var i = 0; i < 3; i++)
                await producerService.SendMessageAsync(configuration["Kafka:TopicName"]!,
                    $"Message {i + 1}: {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
    }
}