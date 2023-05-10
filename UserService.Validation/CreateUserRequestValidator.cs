using FluentValidation;
using UserService.Data.Interfaces;
using UserService.Models.Dto.Requests.User;
using UserService.Validation.Interfaces;

namespace UserService.Validation;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>, ICreateUserRequestValidator
{
    public CreateUserRequestValidator(
      IUserRepository userRepository,
      IUserGroupRepository userGroupRepository)
    {
        RuleFor(u => u.Login)
            .MinimumLength(5)
            .WithMessage("Login must be at least 5 characters long")
            .MaximumLength(15)
            .WithMessage("Login must be no more than 15 characters long")
            .MustAsync(async (login, _) => !await userRepository.DoesExistLoginAsync(login))
            .WithMessage("User with this login already exists.");

        RuleFor(u => u.Password)
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long")
            .MaximumLength(15)
            .WithMessage("Password must be no more than 15 characters long");

        RuleFor(u => u.UserGroup)
          .MustAsync(async (userGroup, _) => await userGroupRepository.GetGroupIdAsync(userGroup) is not null)
          .WithMessage("This group doesn't exist.")
          .MustAsync(async (userGroup, _) => !await userGroupRepository.DoesExistAdminAsync(userGroup))
          .WithMessage("There is already a user with group admin.");
    }
}