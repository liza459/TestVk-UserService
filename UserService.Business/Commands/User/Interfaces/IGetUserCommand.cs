using UserService.Models.Dto.Models;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.User.Interfaces;

public interface IGetUserCommand
{
    Task<OperationResultResponse<UserInfo?>> ExecuteAsync(Guid id);
}
