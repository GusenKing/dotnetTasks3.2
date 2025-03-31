using Task1.Server.Services;
using Task1.Server.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IWeatherApiCallingService, OpenMeteoApiCallingService>();
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<WeatherStreamingService>();

app.Run();