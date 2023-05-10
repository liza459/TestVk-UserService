using UserService.Business.Commands.User.Interfaces;
using UserService.Data.Interfaces;
using UserService.Mappers.Db.Interfaces;
using UserService.Models.Dto.Requests.User;
using UserService.Models.Dto.Response;
using UserService.Validation.Interfaces;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace UserService.Business.Commands.User;

public class CreateUserCommand : ICreateUserCommand
{
    private readonly IDbUserMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IUserStateRepository _userStateRepository;
    public readonly ICreateUserRequestValidator _validator;

    public CreateUserCommand(
      IDbUserMapper mapper,
      IUserRepository userRepository,
      IUserGroupRepository userGroupRepository,
      IUserStateRepository userStateRepository,
      ICreateUserRequestValidator validator)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userStateRepository = userStateRepository;
        _userGroupRepository = userGroupRepository;
        _validator = validator;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateUserRequest request)
    {
        Guid? groupId = await _userGroupRepository.GetGroupIdAsync(request.UserGroup.ToLower());
        Guid? stateId = await _userStateRepository.GetStateIdAsync("active");

        OperationResultResponse<Guid?> response = new();

        ValidationResult validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            response.Errors = validationResult.Errors.ConvertAll(er => er.ErrorMessage);
            return response;
        } 

        if (stateId is null)
        {
            response.Errors = new List<string> { "\"Active\" status must be created." };
            return response;
        }

        response.Body = await _userRepository.CreateAsync(_mapper.Map(request, (Guid)groupId, (Guid)stateId));

        if(response.Body is null) 
        {
            response.Errors = new List<string> { "User with this login already exists." };
        }

        return response;
    }
}
