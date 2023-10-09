using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<AppUser>? _userManager;

        public DeleteUserCommandHandler(UserManager<AppUser>? userManager) => _userManager = userManager;

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager!.FindByIdAsync(request.Id!);
            if(user == null)
                throw new NotFoundException(nameof(AppUser), request.Id!);

            await _userManager.DeleteAsync(user);

            return Unit.Value;
        }
    }
}
