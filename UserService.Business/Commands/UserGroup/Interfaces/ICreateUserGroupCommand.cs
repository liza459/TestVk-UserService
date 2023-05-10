using UserService.Models.Dto.Requests.UserGroup;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.UserGroup.Interfaces;

public interface ICreateUserGroupCommand
{
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateUserGroupRequest request);
}
