using Clickhouse.Models;
using Clickhouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clickhouse.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUsersRepository usersRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAllUsers()
    {
        try
        {
            return Results.Ok(await usersRepository.GetAllAsync());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> AddUser([FromBody] User user)
    {
        try
        {
            return Results.Ok(await usersRepository.InsertAsync(user));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IResult> AddUser(uint userId)
    {
        try
        {
            await usersRepository.DeleteByIdAsync(userId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    [Route("/get-user")]
    public async Task<IResult> GetUser([FromQuery] string name)
    {
        try
        {
            return Results.Ok(await usersRepository.SearchByNameAsync(name));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    [Route("/get-users")]
    public async Task<IResult> GetUser([FromQuery] string name, [FromQuery] ushort age)
    {
        try
        {
            return Results.Ok(await usersRepository.SearchByNameAndOrAgeAsync(name, age));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}