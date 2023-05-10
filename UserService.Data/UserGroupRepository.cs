using Microsoft.EntityFrameworkCore;
using UserService.Data.Interfaces;
using UserService.Data.Provider.Sql.Ef;
using UserService.Models.Db;

namespace UserService.Data;

public class UserGroupRepository : IUserGroupRepository
{
    private readonly UserServiceDbContext _provider;
    public UserGroupRepository(UserServiceDbContext provider)
    {
        _provider = provider;
    }

    public async Task<Guid?> CreateAsync(DbUserGroup dbUserGroup)
    {
        if (dbUserGroup is null)
        {
            return null;
        }

        await _provider.UsersGroup.AddAsync(dbUserGroup);
        await _provider.SaveChangesAsync();
        return dbUserGroup.Id;
    }

    public async Task<Guid?> GetGroupIdAsync(string group)
    {
        DbUserGroup? dbUserGroup = await _provider.UsersGroup.AsNoTracking().FirstOrDefaultAsync(ug => ug.Group == group);
        return dbUserGroup?.Id;
    }

    public async Task<bool> DoesExistAdminAsync(string group)
    {
        if (group == "admin")
        {
            return await _provider.Users.Include(u => u.UserState).Include(u => u.UserGroup)
                .AnyAsync(u => u.UserState.State == "active" && u.UserGroup.Group == "admin");
        }

        return false;
    }
}
