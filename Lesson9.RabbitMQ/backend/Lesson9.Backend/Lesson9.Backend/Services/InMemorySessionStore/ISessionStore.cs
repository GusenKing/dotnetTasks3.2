namespace Lesson9.Backend.Services.InMemorySessionStore;

public interface ISessionStore
{
    bool TryGetOldSession(string username, out string oldToken);
    void RegisterSession(string username, string token);
    void RemoveSession(string username);
}