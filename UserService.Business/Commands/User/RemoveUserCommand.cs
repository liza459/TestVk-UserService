using UserService.Business.Commands.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.User;

public class RemoveUserCommand : IRemoveUserCommand
{
    private readonly IUserRepository _userRepository;
    private readonly IUserStateRepository _userStateRepository;

    public RemoveUserCommand(
      IUserRepository userRepository,
      IUserStateRepository userStateRepository)
    {
        _userRepository = userRepository;
        _userStateRepository = userStateRepository;
    }

    public async Task<OperationResultResponse<bool>> ExecuteAsync(Guid id)
    {
        OperationResultResponse<bool> response = new();

        if (!await _userRepository.DoesExistUserAsync(id))
        {
            response.Errors = new List<string> { "User with this id does not exist." };
            response.Body = false;
            return response;
        }

        if (await _userStateRepository.GetStateIdAsync("blocked") is null)
        {
            response.Errors = new List<string> { "\"Blocked\" status must be created." };
            response.Body = false;
            return response;
        }

        await _userRepository.RemoveAsync(id);
        response.Body = true;

        return response;
    }
}
