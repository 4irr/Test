using MediatR;

namespace Application.AppUsers.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public string? Id { get; set; }
    }
}
