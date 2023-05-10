using UserService.Business.Commands.UserGroup.Interfaces;
using UserService.Data.Interfaces;
using UserService.Mappers.Db.Interfaces;
using UserService.Models.Dto.Requests.UserGroup;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.UserGroup;

public class CreateUserGroupCommand : ICreateUserGroupCommand
{
    private readonly IDbUserGroupMapper _mapper;
    private readonly IUserGroupRepository _repository;

    public CreateUserGroupCommand(
      IDbUserGroupMapper mapper,
      IUserGroupRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateUserGroupRequest request)
    {
        OperationResultResponse<Guid?> response = new OperationResultResponse<Guid?>();

        if (await _repository.GetGroupIdAsync(request.Group.ToLower()) is not null)
        {
            response.Errors = new List<string> { "Group already exists with the same name." };
            return response;
        }

        response.Body = await _repository.CreateAsync(_mapper.Map(request));

        return response;
    }
}
