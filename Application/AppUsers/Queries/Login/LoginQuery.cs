using MediatR;

namespace Application.AppUsers.Queries.Login
{
    public class LoginQuery : IRequest<AppUserDto>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
