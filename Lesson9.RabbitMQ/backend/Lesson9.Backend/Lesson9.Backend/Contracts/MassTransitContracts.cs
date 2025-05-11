namespace Lesson9.Backend.Contracts;

public record LoginRequest(string Username, Guid RequestId);
public record LoginResponse(bool Success, Guid SessionId);
public record ValidateRequest(Guid SessionId);
public record ValidateResponse(bool Valid);
public record KickOut(Guid SessionId);
public record UpdateMessage(string Payload);