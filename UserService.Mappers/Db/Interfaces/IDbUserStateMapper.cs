using UserService.Models.Db;
using UserService.Models.Dto.Requests.UserState;

namespace UserService.Mappers.Db.Interfaces;

public interface IDbUserStateMapper
{
    DbUserState Map(CreateUserStateRequest request);
}
