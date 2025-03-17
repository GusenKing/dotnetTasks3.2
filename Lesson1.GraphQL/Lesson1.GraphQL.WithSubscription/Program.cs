using Lesson1.GraphQL.WithSubscription.GraphQL;
using Lesson1.GraphQL.WithSubscription.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PeriodicNumberService>();
builder.Services.AddHostedService(
    provider => provider.GetRequiredService<PeriodicNumberService>());

builder.Services.AddGraphQLServer().AddInMemorySubscriptions().AddSubscriptionType<Subscription>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true).ModifyOptions(opt => opt.StrictValidation = false);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseWebSockets();
app.MapGraphQL();

app.Run();