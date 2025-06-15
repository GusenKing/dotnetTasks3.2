using Confluent.Kafka;

namespace Lesson14.KafkaConsumer.Services;

public class KafkaConsumerService(ILogger<KafkaConsumerService> logger, IConfiguration configuration)
    : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer = new ConsumerBuilder<Null, string>
    (
        new ConsumerConfig
        {
            BootstrapServers = configuration["Kafka:BootstrapServer"]!,
            GroupId = configuration["Kafka:GroupId"]!,
            AutoOffsetReset = AutoOffsetReset.Earliest
        }
    ).Build();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe(configuration["Kafka:TopicName"]);
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume(stoppingToken);
                logger.LogInformation("Consumed message: {MessageValue}", consumeResult.Message.Value);
                await Task.Delay(TimeSpan.FromSeconds(4), stoppingToken);
            }
        }
        catch (ConsumeException e)
        {
            Console.WriteLine($"Error consuming message: {e.Error.Reason}");
        }
    }
}