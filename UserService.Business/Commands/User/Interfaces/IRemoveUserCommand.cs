using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.User.Interfaces;

public interface IRemoveUserCommand
{
    Task<OperationResultResponse<bool>> ExecuteAsync(Guid id);
}
