using Lesson14.KafkaConsumer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<KafkaConsumerService>();
builder.Services.AddHostedService(provider => provider.GetRequiredService<KafkaConsumerService>());

var app = builder.Build();
app.Run();