using MediatR;

namespace Application.AppUsers.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
