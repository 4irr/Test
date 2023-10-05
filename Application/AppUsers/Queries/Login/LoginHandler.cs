using Application.Common.Exceptions;
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

        public LoginHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                user.Token = "Test Token";
                return user;
            }

            throw new NotFoundException(nameof(AppUser), request.UserName!);
        }
    }
}
