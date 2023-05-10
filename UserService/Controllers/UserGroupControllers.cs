using Microsoft.AspNetCore.Mvc;
using UserService.Business.Commands.UserGroup.Interfaces;
using UserService.Models.Dto.Requests.UserGroup;
using UserService.Models.Dto.Response;

namespace UserService.Controllers;

[Route("[controller]")]
[ApiController]
public class UserGroupController : ControllerBase
{
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> CreateAsync(
      [FromServices] ICreateUserGroupCommand command,
      [FromBody] CreateUserGroupRequest request)
    {
        OperationResultResponse<Guid?> response = await command.ExecuteAsync(request);

        if (response.Errors.Count > 0)
        {
            HttpContext.Response.StatusCode = 400;
        }

        return response;
    }
}
