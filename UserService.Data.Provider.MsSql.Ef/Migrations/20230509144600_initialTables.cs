using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using UserService.Models.Db;

namespace UserService.Data.Provider.Sql.Ef.Migrations;

[DbContext(typeof(UserServiceDbContext))]
[Migration("20230509144600_InitialTables")]
public class InitialTables : Migration
{
    private void CreateUsersTable(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: DbUser.TableName,
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Login = table.Column<string>(nullable: false),
                Password = table.Column<string>(nullable: false),
                CreatedDate = table.Column<DateTime>(nullable: false),
                UserGroupId = table.Column<Guid>(nullable: false),
                UserStateId = table.Column<Guid>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey($"PK_{DbUser.TableName}", u => u.Id);
                table.UniqueConstraint($"UX_{DbUser.TableName}_Login_unique", x => x.Login);
            });
    }

    private void CreateUsersGroupTable(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: DbUserGroup.TableName,
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Group = table.Column<string>(nullable: false),
                Description = table.Column<string>(nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey($"PK_{DbUserGroup.TableName}", ug => ug.Id);
            });
    }

    private void CreateUsersStateTable(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: DbUserState.TableName,
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                State = table.Column<string>(nullable: false),
                Description = table.Column<string>(nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey($"PK_{DbUserState.TableName}", ug => ug.Id);
            });
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        CreateUsersTable(migrationBuilder);
        CreateUsersGroupTable(migrationBuilder);
        CreateUsersStateTable(migrationBuilder);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(DbUser.TableName);
        migrationBuilder.DropTable(DbUserGroup.TableName);
        migrationBuilder.DropTable(DbUserState.TableName);
    }
}
