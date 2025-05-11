using System.Collections.Concurrent;
using Lesson9.Backend.Services.BackgroundServices;
using Lesson9.Backend.Services.Consumers;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(new ConcurrentDictionary<string, Guid>());

var rabbitSettings = builder.Configuration.GetSection("RabbitMQ");
builder.Services.AddMassTransit(x =>
    {
        x.AddConsumer<LoginConsumer>();
        x.AddConsumer<ValidateConsumer>();

        x.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host(rabbitSettings["Host"], rabbitSettings["VHost"], hostConfigurator =>
            {
                hostConfigurator.Username(rabbitSettings["Username"]!);
                hostConfigurator.Password(rabbitSettings["Password"]!);
            });

            cfg.ReceiveEndpoint("login-service",
                endpointConfigurator => endpointConfigurator.ConfigureConsumer<LoginConsumer>(ctx));
            cfg.ReceiveEndpoint("validate-service",
                endpointConfigurator => endpointConfigurator.ConfigureConsumer<ValidateConsumer>(ctx));
        });

        x.AddPublishMessageScheduler();
    }
);

builder.Services.AddHostedService<UpdatePublisher>();


var host = builder.Build();
host.Run();