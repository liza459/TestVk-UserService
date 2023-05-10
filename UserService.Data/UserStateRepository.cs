using Microsoft.EntityFrameworkCore;
using UserService.Data.Interfaces;
using UserService.Data.Provider.Sql.Ef;
using UserService.Models.Db;

namespace UserService.Data;

public class UserStateRepository : IUserStateRepository
{
    private readonly UserServiceDbContext _provider;
    public UserStateRepository(UserServiceDbContext provider)
    {
        _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbUserState dbUserState)
    {
        if (dbUserState is null)
        {
            return null;
        }

        await _provider.UsersState.AddAsync(dbUserState);
        await _provider.SaveChangesAsync();
        return dbUserState.Id;
    }

    public async Task<Guid?> GetStateIdAsync(string state)
    {
        DbUserState? dbUserState = await _provider.UsersState.AsNoTracking().FirstOrDefaultAsync(ug => ug.State == state);
        return dbUserState?.Id;
    }
}
