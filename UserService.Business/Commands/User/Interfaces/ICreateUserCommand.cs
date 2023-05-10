using UserService.Models.Dto.Requests.User;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.User.Interfaces;

public interface ICreateUserCommand
{
    Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateUserRequest request);
}
