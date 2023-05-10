using UserService.Models.Dto.Requests.UserState;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.UserState.Interfaces;

public interface ICreateUserStateCommand
{
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateUserStateRequest request);
}
