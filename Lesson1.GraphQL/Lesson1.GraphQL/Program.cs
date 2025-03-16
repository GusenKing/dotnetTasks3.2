using Lesson1.GraphQL;
using Lesson1.GraphQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddGraphQLServer().AddQueryType<PeopleQuery>().AddProjections().AddFiltering().AddSorting()
    .RegisterDbContextFactory<AppDbContext>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();