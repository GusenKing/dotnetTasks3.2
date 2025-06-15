using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace Lesson14.KafkaProducer.Utilities;

public static class KafkaUtility
{
    public static async Task CreateTopicAsync(string bootstrapServer, string topicName)
    {
        using var adminClient = new AdminClientBuilder(new AdminClientConfig
        {
            BootstrapServers = bootstrapServer
        }).Build();

        try
        {
            await adminClient.CreateTopicsAsync([
                new TopicSpecification
                {
                    Name = topicName,
                    ReplicationFactor = 1,
                    NumPartitions = 1,
                    Configs = new Dictionary<string, string>
                    {
                        { "retention.ms", "6000" },
                        { "segment.ms", "7000" },
                        { "cleanup.policy", "delete" }
                    }
                }
            ]);
        }
        catch (CreateTopicsException e)
        {
            Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
        }
    }
}