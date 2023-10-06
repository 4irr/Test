using Application.AppUsers.Enums;
using MediatR;

namespace Application.AppUsers.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public AppUserSortState SortState { get; set; }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public int Page { get; set; }
    }
}
