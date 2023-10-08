using FluentValidation;

namespace Application.AppUsers.Commands.AddRoleToUser
{
    public class AddRoleToUserCommandValidator : AbstractValidator<AddRoleToUserCommand>
    {
        public AddRoleToUserCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.Roles).NotNull()
                .Must(roles => roles?.Count > 0).WithMessage("Необохидмо ввести минимум одну роль");
            RuleForEach(command => command.Roles).IsInEnum().WithMessage("Введено неверное значение");
        }
    }
}
