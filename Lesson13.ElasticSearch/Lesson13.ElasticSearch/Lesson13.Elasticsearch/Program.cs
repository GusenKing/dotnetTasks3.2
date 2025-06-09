using Lesson13.Elasticsearch.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IElasticsearchClientProvider, ElasticsearchClientProvider>();
builder.Services.AddTransient<SingleWordService>();

var app = builder.Build();
var service = app.Services.GetRequiredService<SingleWordService>();

await service.TryCreateIndexAndAddWords("Data/lorem-ipsum.txt");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();