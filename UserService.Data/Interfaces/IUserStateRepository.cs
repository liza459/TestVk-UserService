using UserService.Models.Db;

namespace UserService.Data.Interfaces;

public interface IUserStateRepository
{
    Task<Guid?> CreateAsync(DbUserState dbUserState);
    Task<Guid?> GetStateIdAsync(string state);
}
