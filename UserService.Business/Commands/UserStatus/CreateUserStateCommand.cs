using UserService.Business.Commands.UserState.Interfaces;
using UserService.Data.Interfaces;
using UserService.Mappers.Db.Interfaces;
using UserService.Models.Dto.Requests.UserState;
using UserService.Models.Dto.Response;

namespace UserService.Business.Commands.UserState;

public class CreateUserStateCommand : ICreateUserStateCommand
{
    private readonly IDbUserStateMapper _mapper;
    private readonly IUserStateRepository _repository;

    public CreateUserStateCommand(
      IDbUserStateMapper mapper,
      IUserStateRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateUserStateRequest request)
    {
        OperationResultResponse<Guid?> response = new OperationResultResponse<Guid?>();

        if (await _repository.GetStateIdAsync(request.State.ToLower()) is not null)
        {
            response.Errors = new List<string> { "State already exists with the same name." };
            return response;
        }

        response.Body = await _repository.CreateAsync(_mapper.Map(request));

        return response;

    }
}
