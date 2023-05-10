using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserService.Models.Db;
public class DbUser
{
    public const string TableName = "Users";

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid UserGroupId { get; set; }
    public Guid UserStateId { get; set; }

    public DbUserGroup UserGroup { get; set; }
    public DbUserState UserState { get; set; }

    public void Configure(EntityTypeBuilder<DbUser> builder)
    {
        builder
          .ToTable(TableName);

        builder
            .HasKey(t => t.Id);

        builder
          .HasOne(u => u.UserGroup)
          .WithMany(ug => ug.Users);

        builder
         .HasOne(u => u.UserState)
         .WithMany(us => us.Users);
    }
}