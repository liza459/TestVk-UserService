using UserService.Mappers.Db.Interfaces;
using UserService.Models.Db;
using UserService.Models.Dto.Requests.UserState;

namespace UserService.Mappers.Db;

public class DbUserStateMapper: IDbUserStateMapper
{
    public DbUserState Map(CreateUserStateRequest request)
    {
        return request is null
          ? null
          : new DbUserState
          {
              Id = Guid.NewGuid(),
              State = request.State.ToLower(),
              Description = request.Description,
          };
    }
}
