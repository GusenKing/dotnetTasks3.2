using Lesson14.KafkaProducer.Services;
using Lesson14.KafkaProducer.Utilities;

var builder = WebApplication.CreateBuilder(args);
await KafkaUtility.CreateTopicAsync(builder.Configuration["Kafka:BootstrapServer"]!,
    builder.Configuration["Kafka:TopicName"]!);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<IKafkaProducerService, KafkaProducerService>();
builder.Services.AddSingleton<PeriodicHostedService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<PeriodicHostedService>());

var app = builder.Build();

app.Run();