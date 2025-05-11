using System.Text;
using Lesson9.Backend.Contracts;
using Lesson9.Backend.Services.BackgroundServices;
using Lesson9.Backend.Services.InMemorySessionStore;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

var jwtKey = builder.Configuration["Jwt:Key"];
var keyBytes = Encoding.UTF8.GetBytes(jwtKey!);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddSingleton<ISessionStore, InMemorySessionStore>();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        var mq = builder.Configuration.GetSection("RabbitMq");
        cfg.Host(mq["Host"], h =>
        {
            h.Username(mq["Username"]!);
            h.Password(mq["Password"]!);
        });

        cfg.Message<LogoutRequested>(m => m.SetEntityName("logout_exchange"));
        cfg.Publish<LogoutRequested>(p =>
        {
            p.ExchangeType = ExchangeType.Topic;
            p.Durable = true;
            p.AutoDelete = false;
        });

        cfg.Message<UserNotification>(m => m.SetEntityName("backend_exchange"));
        cfg.Publish<UserNotification>(p =>
        {
            p.ExchangeType = ExchangeType.Fanout;
            p.Durable = true;
            p.AutoDelete = false;
        });
    });
});

builder.Services.AddHostedService<UpdatePublisher>();

builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();