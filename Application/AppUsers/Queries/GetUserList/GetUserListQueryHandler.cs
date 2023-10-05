using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AppUsers.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly UserManager<AppUser>? _userManager;
        public GetUserListQueryHandler(UserManager<AppUser> userManager) => _userManager = userManager;
        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager?.Users.ToListAsync()!;
            return new UserListVm { Users = users };
        }
    }
}
