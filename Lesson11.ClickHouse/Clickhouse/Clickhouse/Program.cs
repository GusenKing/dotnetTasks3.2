using Clickhouse.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsersRepository, ClickhouseService>();
builder.Services.AddScoped<IClickhouseWrapper, ClickhouseService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var clickhouseWrapper = services.GetRequiredService<IClickhouseWrapper>();
await clickhouseWrapper.CreateTableIfNotExistAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();