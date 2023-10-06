using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Queries.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, AppUserDto>
    {
        private readonly UserManager<AppUser>? _userManager;
        private readonly SignInManager<AppUser>? _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;

        public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public async Task<AppUserDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager!.FindByNameAsync(request.UserName!);
            if (user == null)
            {
                throw new NotFoundException(nameof(AppUser), request.UserName!);
            }

            var result = await _signInManager!.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                user.Token = _jwtGenerator.CreateToken(user);
                var userDto = _mapper.Map<AppUserDto>(user);
                return userDto;
            }

            throw new NotFoundException(nameof(AppUser), request.UserName!);
        }
    }
}
