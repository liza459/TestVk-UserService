using FluentValidation;
using UserService.Models.Dto.Requests.User;

namespace UserService.Validation.Interfaces;

public interface ICreateUserRequestValidator : IValidator<CreateUserRequest>
{
}
