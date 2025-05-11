using System.Collections.Concurrent;

namespace Lesson9.Backend.Services.InMemorySessionStore;

public class InMemorySessionStore : ISessionStore
{
    private readonly ConcurrentDictionary<string, string> _sessions = new();

    public bool TryGetOldSession(string username, out string oldToken)
    {
        return _sessions.TryGetValue(username, out oldToken);
    }

    public void RegisterSession(string username, string token)
    {
        _sessions[username] = token;
    }

    public void RemoveSession(string username)
    {
        _sessions.TryRemove(username, out _);
    }
}