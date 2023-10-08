using Application.Roles.Enums;
using MediatR;

namespace Application.AppUsers.Commands.AddRoleToUser
{
    public class AddRoleToUserCommand : IRequest
    {
        public string? Id { get; set; }
        public List<UserRoles>? Roles { get; set; }
    }
}
