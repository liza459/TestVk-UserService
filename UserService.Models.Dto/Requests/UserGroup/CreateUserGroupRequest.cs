using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Dto.Requests.UserGroup;

public class CreateUserGroupRequest
{
    [Required]
    public string Group { get; set; }
    public string Description { get; set; }
}
