using Microsoft.AspNetCore.Mvc;
using UserService.Business.Commands.UserState.Interfaces;
using UserService.Models.Dto.Requests.UserState;
using UserService.Models.Dto.Response;

namespace UserService.Controllers;

[Route("[controller]")]
[ApiController]
public class UserStateController : ControllerBase
{
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateUserStateCommand command,
      [FromBody] CreateUserStateRequest request)
    {
        OperationResultResponse<Guid?> response = await command.ExecuteAsync(request);

        if (response.Errors.Count > 0)
        {
            HttpContext.Response.StatusCode = 400;
        }

        return response;
    }
}
