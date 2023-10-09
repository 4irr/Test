using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                DisplayName = request.DisplayName,
                UserName = request.UserName,
                Email = request.Email,
                Age = request.Age
            };

            await _userManager.CreateAsync(user, request.Password!);
            await _userManager.AddToRoleAsync(user, "User");

            return user.Id;
        }
    }
}
