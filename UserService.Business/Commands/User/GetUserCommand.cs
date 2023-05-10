using UserService.Business.Commands.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Mappers.Models.Interfaces;
using UserService.Models.Db;
using UserService.Models.Dto.Models;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.User;

public class GetUserCommand : IGetUserCommand
{
    private readonly IUserRepository _userRepository;
    private readonly IUserInfoMapper _mapper;

    public GetUserCommand(
      IUserRepository userRepository,
      IUserInfoMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<OperationResultResponse<UserInfo?>> ExecuteAsync(Guid id)
    {
        OperationResultResponse<UserInfo?> response = new();

        if (!await _userRepository.DoesExistUserAsync(id))
        {
            response.Errors = new List<string> { "User with this id does not exist." };
            return response;
        }

        List<DbUser> users = new List<DbUser> ();
        users.Add(await _userRepository.GetAsync(id));
        response.Body = _mapper.Map(users).First();

        return response;
    }
}
