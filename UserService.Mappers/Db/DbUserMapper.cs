using UserService.Mappers.Db.Interfaces;
using UserService.Models.Db;
using UserService.Models.Dto.Requests.User;

namespace UserService.Mappers.Db;

public class DbUserMapper: IDbUserMapper
{
    public DbUser Map(CreateUserRequest request, Guid groupId, Guid stateId)
    {
        return request is null
          ? null
          : new DbUser
          {
              Id = Guid.NewGuid(),
              Login = request.Login,
              Password = request.Password,
              CreatedDate = DateTime.UtcNow,
              UserGroupId = groupId,
              UserStateId = stateId
          };
    }
}
