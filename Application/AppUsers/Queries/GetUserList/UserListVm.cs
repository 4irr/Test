using Application.AppUsers.Queries.Login;

namespace Application.AppUsers.Queries.GetUserList
{
    public class UserListVm
    {
        public IList<AppUserDto>? Users { get; set; }
    }
}
