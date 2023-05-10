using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Dto.Requests.UserState;

public class CreateUserStateRequest
{
    [Required]
    public string State { get; set; }
    public string Description { get; set; }
}
