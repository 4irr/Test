using Application.Common.Exceptions;
using Application.Interfaces;
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
    public class LoginHandler : IRequestHandler<LoginQuery, AppUser>
    {
        private readonly UserManager<AppUser>? _userManager;

        private readonly SignInManager<AppUser>? _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AppUser> Handle(LoginQuery request, CancellationToken cancellationToken)
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
                return user;
            }

            throw new NotFoundException(nameof(AppUser), request.UserName!);
        }
    }
}
