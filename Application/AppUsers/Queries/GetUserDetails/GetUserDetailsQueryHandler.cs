using Application.AppUsers.Queries.GetUserList;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly UserManager<AppUser>? _userManager;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(UserManager<AppUser> userManager,
            IMapper mapper) => (_userManager, _mapper) = (userManager, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager!.FindByIdAsync(request.Id!);
            if (user == null)
            {
                throw new NotFoundException(nameof(AppUser), request.Id!);
            }

            var userVm = _mapper.Map<UserDetailsVm>(user);
            userVm.Roles = await _userManager.GetRolesAsync(user);

            return userVm;
        }
    }
}
