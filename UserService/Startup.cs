using Microsoft.EntityFrameworkCore;
using UserService.Business.Commands.User;
using UserService.Business.Commands.User.Interfaces;
using UserService.Business.Commands.UserGroup;
using UserService.Business.Commands.UserGroup.Interfaces;
using UserService.Business.Commands.UserState;
using UserService.Business.Commands.UserState.Interfaces;
using UserService.Data;
using UserService.Data.Interfaces;
using UserService.Data.Provider.Sql.Ef;
using UserService.Mappers.Db;
using UserService.Mappers.Db.Interfaces;
using UserService.Mappers.Models;
using UserService.Mappers.Models.Interfaces;
using UserService.Validation;
using UserService.Validation.Interfaces;

namespace UserService;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

        using (UserServiceDbContext context = new UserServiceDbContext())
        {
            context.Database.Migrate();
        }
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICreateUserCommand, CreateUserCommand>();
        services.AddTransient<IRemoveUserCommand, RemoveUserCommand>();
        services.AddTransient<IGetUserCommand, GetUserCommand>();
        services.AddTransient<ICreateUserGroupCommand, CreateUserGroupCommand>();
        services.AddTransient<ICreateUserStateCommand, CreateUserStateCommand>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserGroupRepository, UserGroupRepository>();
        services.AddTransient<IUserStateRepository, UserStateRepository>();
        services.AddTransient<IDbUserMapper, DbUserMapper>();
        services.AddTransient<IUserInfoMapper, UserInfoMapper>();
        services.AddTransient<IDbUserGroupMapper, DbUserGroupMapper>();
        services.AddTransient<IDbUserStateMapper, DbUserStateMapper>();
        services.AddTransient<ICreateUserRequestValidator, CreateUserRequestValidator>();

        services.AddControllers();

        services.AddDbContext<UserServiceDbContext>();
    }

    public void Configure(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
