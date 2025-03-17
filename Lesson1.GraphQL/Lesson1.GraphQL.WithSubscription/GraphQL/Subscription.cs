namespace Lesson1.GraphQL.WithSubscription.GraphQL;

public class Subscription
{
    [Subscribe]
    public long OnNumberGenerated([EventMessage] long number)
    {
        return number;
    }
}