using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lesson9.Backend.Contracts;
using Lesson9.Backend.Dtos;
using Lesson9.Backend.Services.InMemorySessionStore;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Lesson9.Backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IConfiguration config, ISessionStore sessions, IPublishEndpoint publisher)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (dto.Password != "1234")
            return Unauthorized();

        if (sessions.TryGetOldSession(dto.Username, out var oldToken))
            await publisher.Publish(new LogoutRequested(dto.Username),
                ctx => ctx.SetRoutingKey($"user.{dto.Username}"));

        // Генерируем JWT
        var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, dto.Username)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        sessions.RegisterSession(dto.Username, token);

        return Ok(new { token, user = new { username = dto.Username } });
    }

    [Authorize]
    [HttpGet("check")]
    public IActionResult Check()
    {
        var uname = HttpContext.User.Identity!.Name;
        return Ok(new { username = uname });
    }
}