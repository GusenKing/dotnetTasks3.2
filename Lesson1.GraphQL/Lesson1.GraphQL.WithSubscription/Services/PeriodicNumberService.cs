using HotChocolate.Subscriptions;
using Lesson1.GraphQL.WithSubscription.GraphQL;

namespace Lesson1.GraphQL.WithSubscription.Services;

public class PeriodicNumberService([Service] ITopicEventSender sender) : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromSeconds(1);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var rnd = new Random();
        using var timer = new PeriodicTimer(_period);
        while (
            !stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
            await sender.SendAsync(nameof(Subscription.OnNumberGenerated), rnd.NextInt64(), stoppingToken);
    }
}