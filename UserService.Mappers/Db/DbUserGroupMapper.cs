using UserService.Mappers.Db.Interfaces;
using UserService.Models.Db;
using UserService.Models.Dto.Requests.UserGroup;

namespace UserService.Mappers.Db;

public class DbUserGroupMapper: IDbUserGroupMapper
{
    public DbUserGroup Map(CreateUserGroupRequest request)
    {
        return request is null
          ? null
          : new DbUserGroup
          {
              Id = Guid.NewGuid(),
              Group = request.Group.ToLower(),
              Description = request.Description,
          };
    }
}
