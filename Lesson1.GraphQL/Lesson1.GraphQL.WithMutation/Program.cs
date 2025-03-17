using Lesson1.GraphQL.WithMutation.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering()
    .AddMutationType<Mutation>()
    .AddMutationConventions().ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

var app = builder.Build();

app.MapGraphQL();
app.RunWithGraphQLCommands(args);

app.Run();