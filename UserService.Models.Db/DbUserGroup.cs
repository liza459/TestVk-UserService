using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UserService.Models.Db;

public class DbUserGroup
{
    public const string TableName = "UsersGroup";

    public Guid Id { get; set; }
    public string Group { get; set; }
    public string Description { get; set; }

    public ICollection<DbUser> Users { get; set; }

    public DbUserGroup() => Users = new HashSet<DbUser>();

    public class DbUserGroupConfiguration : IEntityTypeConfiguration<DbUserGroup>
    {
        public void Configure(EntityTypeBuilder<DbUserGroup> builder)
        {
            builder
              .ToTable(TableName);

            builder
                .HasKey(t => t.Id);

            builder
              .HasMany(ug => ug.Users)
              .WithOne(u => u.UserGroup);
        }
    }
}
