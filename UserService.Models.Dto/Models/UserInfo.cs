namespace UserService.Models.Dto.Models;

public class UserInfo
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserGroup { get; set; }
    public string UserGroupDescription { get; set; }
    public string UserState { get; set; }
    public string UserStateDescription { get; set; }
}
