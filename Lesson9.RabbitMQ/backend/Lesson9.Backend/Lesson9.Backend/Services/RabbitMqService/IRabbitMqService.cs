namespace Lesson9.Backend.Services.RabbitMqService;

public interface IRabbitMqService
{
    void PublishLogout(string username);
    void PublishUserMessage(string username, string message);
}