using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Application.AppUsers.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly UserManager<AppUser>? _userManager;

        public UpdateUserCommandHandler(UserManager<AppUser>? userManager) => _userManager = userManager;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager!.FindByIdAsync(request.Id!);
            if (user == null)
                throw new NotFoundException(nameof(AppUser), request.Id!);

            user.DisplayName = request.DisplayName;
            user.Age = request.Age;
            user.Email = request.Email;

            var userRoles = await _userManager.GetRolesAsync(user);
            var addedRoles = request.Roles!.Select(r => r.ToString()).Except(userRoles);
            var removedRoles = userRoles.Except(request.Roles!.Select(r => r.ToString()));

            await _userManager.AddToRolesAsync(user, addedRoles);

            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var result = await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
