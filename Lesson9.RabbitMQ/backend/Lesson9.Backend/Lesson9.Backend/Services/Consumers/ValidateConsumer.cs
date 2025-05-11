using System.Collections.Concurrent;
using Lesson9.Backend.Contracts;
using MassTransit;

namespace Lesson9.Backend.Services.Consumers;

public class ValidateConsumer(ConcurrentDictionary<string, Guid> sessions) : IConsumer<ValidateRequest>
{
    public Task Consume(ConsumeContext<ValidateRequest> context)
    {
        var valid = sessions.Values.Contains(context.Message.SessionId);
        return context.RespondAsync(new ValidateResponse(valid));
    }
}