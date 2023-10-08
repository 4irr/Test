using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Application.AppUsers.Commands.AddRoleToUser
{
    public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;

        public AddRoleToUserCommandHandler(UserManager<AppUser> userManager) 
            => _userManager = userManager;

        public async Task<Unit> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id!);
            if(user == null) 
                throw new NotFoundException(nameof(AppUser), request.Id!);

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = user?.Roles?.ToList();
            var roles = request?.Roles?.Select(r => r.ToString()).ToList();
            var addedRoles = roles?.Except(userRoles);
            await _userManager.AddToRolesAsync(user!, addedRoles!);


            return Unit.Value;
        }
    }
}
