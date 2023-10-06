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
            IQueryable<AppUser> users = _userManager.Users.AsQueryable();

            // фильтрация
            users = AppUsersFilterService.DoFilter(users, request.Id, request.DisplayName, request.Age, request.Email);

            // сортировка
            users = AppUserSortService.DoSort(users, request.SortState);

            // пагинация
            users = AppUserPaginationService.DoPagination(users, request.Page);

            var usersQuery = await users
                .ProjectTo<AppUserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListVm { Users = usersQuery };
        }
    }
}
