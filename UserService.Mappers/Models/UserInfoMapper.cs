using UserService.Mappers.Models.Interfaces;
using UserService.Models.Db;
using UserService.Models.Dto.Models;

namespace UserService.Mappers.Models;

public class UserInfoMapper: IUserInfoMapper
{
    public List<UserInfo?> Map(List<DbUser> users)
    {
        return users?.Select(u => new UserInfo
        {
            Id = u.Id,
            Login = u.Login,
            Password = u.Password,
            CreatedDate = u.CreatedDate,
            UserGroup = u.UserGroup.Group,
            UserGroupDescription = u.UserGroup.Description,
            UserState = u.UserState.State,
            UserStateDescription = u.UserState.Description,
        }).ToList();
    }
}
