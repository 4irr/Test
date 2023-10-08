using Application.AppUsers.Queries.Login;
using Application.AppUsers.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.AppUsers.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(UserManager<AppUser> userManager, IMapper mapper) => 
            (_userManager, _mapper) = (userManager, mapper);

        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AppUser> users = await _userManager.Users.Include(u => u.Roles).ToListAsync();

            // фильтрация
            users = AppUsersFilterService.DoFilter(users, request.Id, request.DisplayName, request.Age, request.Email, request.Role);

            // сортировка
            users = AppUserSortService.DoSort(users, request.SortState);

            // пагинация
            users = AppUserPaginationService.DoPagination(users, request.Page);

            List<AppUserDto>? usersQuery = new();

            foreach(var user in users)
            {
                var userDto = _mapper.Map<AppUserDto>(user);
                userDto.Roles = await _userManager.GetRolesAsync(user);
                usersQuery.Add(userDto);
            }

            return new UserListVm { Users = usersQuery };
        }
    }
}
