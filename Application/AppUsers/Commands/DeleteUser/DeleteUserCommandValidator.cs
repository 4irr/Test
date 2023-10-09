using FluentValidation;

namespace Application.AppUsers.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator() 
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
