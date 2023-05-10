using UserService.Models.Db;

namespace UserService.Data.Interfaces;

public interface IUserRepository
{
    Task<Guid?> CreateAsync(DbUser dbUser);
    Task<bool> DoesExistLoginAsync(string login);
    Task<bool> DoesExistUserAsync(Guid id);
    Task<bool> RemoveAsync(Guid id);
    Task<DbUser> GetAsync(Guid id);
}
