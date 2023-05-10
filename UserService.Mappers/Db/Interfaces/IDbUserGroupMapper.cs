using UserService.Models.Db;
using UserService.Models.Dto.Requests.UserGroup;

namespace UserService.Mappers.Db.Interfaces;

public interface IDbUserGroupMapper
{
    DbUserGroup Map(CreateUserGroupRequest request);
}
