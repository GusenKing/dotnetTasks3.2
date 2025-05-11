using System.Collections.Concurrent;
using Lesson9.Backend.Contracts;
using MassTransit;

namespace Lesson9.Backend.Services.Consumers;

public class LoginConsumer(ConcurrentDictionary<string, Guid> sessions) : IConsumer<LoginRequest>
{
    public async Task Consume(ConsumeContext<LoginRequest> context)
    {
        var req = context.Message;
        if (sessions.TryRemove(req.Username, out var oldSession))
        {
            await context.Publish(new KickOut(oldSession));
        }
        var newSession = Guid.NewGuid();
        sessions[req.Username] = newSession;
        await context.RespondAsync(new LoginResponse(true, newSession));
    }
}