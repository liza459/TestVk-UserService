using UserService.Models.Db;

namespace UserService.Data.Interfaces;

public interface IUserGroupRepository
{
    Task<Guid?> CreateAsync(DbUserGroup dbUserGroup);
    Task<Guid?> GetGroupIdAsync(string group);
    Task<bool> DoesExistAdminAsync(string group);
}
