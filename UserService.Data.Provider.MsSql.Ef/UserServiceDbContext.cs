using Microsoft.EntityFrameworkCore;
using UserService.Models.Db;

namespace UserService.Data.Provider.Sql.Ef;

public class UserServiceDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=qwerty");
    }

    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbUserGroup> UsersGroup { get; set; }
    public DbSet<DbUserState> UsersState { get; set; }
}