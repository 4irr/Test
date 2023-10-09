using Application.Roles.Enums;
using MediatR;

namespace Application.AppUsers.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public List<UserRoles>? Roles { get; set; }
    }
}
