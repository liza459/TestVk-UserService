using Microsoft.EntityFrameworkCore;
using UserService.Data.Interfaces;
using UserService.Data.Provider.Sql.Ef;
using UserService.Models.Db;

namespace UserService.Data;

public class UserRepository : IUserRepository
{
    private readonly UserServiceDbContext _provider;
    public UserRepository(UserServiceDbContext provider)
    {
        _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbUser dbUser)
    {
        if (dbUser is null)
        {
            return null;
        }

        await _provider.Users.AddAsync(dbUser);
        await _provider.SaveChangesAsync();
        return dbUser.Id;
    }

    public async Task<bool> DoesExistLoginAsync(string login)
    {
        return await _provider.Users.Include(u => u.UserState)
                                    .AnyAsync(u => u.UserState.State == "active" && u.Login == login);
    }

    public async Task<bool> DoesExistUserAsync(Guid id)
    {
        return await _provider.Users.Include(u => u.UserState)
                                    .AnyAsync(u => u.UserState.State == "active" && u.Id == id);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        DbUser user = await _provider.Users.Include(u => u.UserState)
                                           .FirstOrDefaultAsync(u => u.UserState.State == "active" && u.Id == id);
        user.UserState = await _provider.UsersState.FirstOrDefaultAsync(u => u.State == "blocked");

        await _provider.SaveChangesAsync();
        return true;
    }

    public async Task<DbUser> GetAsync(Guid id)
    {
        return await _provider.Users.Include(u => u.UserState)
                                    .Include(u => u.UserGroup)
                                    .FirstOrDefaultAsync(u => u.UserState.State == "active" && u.Id == id);
    }
}
