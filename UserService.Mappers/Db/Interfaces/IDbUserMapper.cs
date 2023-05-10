using UserService.Models.Db;
using UserService.Models.Dto.Requests.User;

namespace UserService.Mappers.Db.Interfaces;

public interface IDbUserMapper
{
    DbUser Map(CreateUserRequest request, Guid groupId, Guid stateId);
}
