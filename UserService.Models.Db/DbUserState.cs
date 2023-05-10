using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UserService.Models.Db;

public class DbUserState
{
    public const string TableName = "UsersState";

    public Guid Id { get; set; }
    public string State { get; set; }
    public string Description { get; set; }

    public ICollection<DbUser> Users { get; set; }

    public DbUserState() => Users = new HashSet<DbUser>();

    public class DbUserStateConfiguration : IEntityTypeConfiguration<DbUserState>
    {
        public void Configure(EntityTypeBuilder<DbUserState> builder)
        {
            builder
              .ToTable(TableName);

            builder
                .HasKey(t => t.Id);

            builder
              .HasMany(us => us.Users)
              .WithOne(u => u.UserState);
        }
    }
}
