using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Dto.Requests.User;

public class CreateUserRequest
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    public string UserGroup { get; set; }
}
