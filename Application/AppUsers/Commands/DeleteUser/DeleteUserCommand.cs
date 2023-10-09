using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string? Id { get; set; }
    }
}
