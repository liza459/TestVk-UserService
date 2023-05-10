using Microsoft.AspNetCore.Mvc;
using UserService.Business.Commands.User.Interfaces;
using UserService.Models.Db;
using UserService.Models.Dto.Models;
using UserService.Models.Dto.Requests.User;
using UserService.Models.Dto.Response;

namespace UserService.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateUserCommand command,
      [FromBody] CreateUserRequest request)
    {
        OperationResultResponse<Guid?> response = await command.ExecuteAsync(request);

        if (response.Errors.Count > 0)
        {
            HttpContext.Response.StatusCode = 400;
        }

        return response;
    }

    [HttpDelete("remove")]
    public async Task<OperationResultResponse<bool>> FindAsync(
    [FromServices] IRemoveUserCommand command,
    [FromQuery] Guid id)
    {
        OperationResultResponse<bool> response = await command.ExecuteAsync(id);

        if (response.Errors.Count > 0)
        {
            HttpContext.Response.StatusCode = 400;
        }

        return response;
    }

    [HttpGet("get")]
    public async Task<OperationResultResponse<UserInfo?>> GetAsync(
    [FromServices] IGetUserCommand command,
    [FromQuery] Guid id)
    {
        OperationResultResponse<UserInfo?> response = await command.ExecuteAsync(id);

        if (response.Errors.Count > 0)
        {
            HttpContext.Response.StatusCode = 400;
        }

        return response;
    }
}
