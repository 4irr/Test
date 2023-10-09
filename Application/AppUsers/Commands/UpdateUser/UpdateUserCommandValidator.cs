using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.AppUsers.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        public UpdateUserCommandValidator(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;

            RuleFor(command => command.DisplayName).NotEmpty();
            RuleFor(command => command.Age).NotEmpty().GreaterThan(0)
                .WithMessage("Возраст должен быть больше нуля");
            RuleFor(command => command.Email).NotEmpty().Must(IsEmailUnique!)
                .WithMessage("Пользователь с таким email уже зарегистрирован");
            RuleFor(command => command.Roles).NotNull()
                .Must(roles => roles?.Count > 0).WithMessage("Необохидмо ввести минимум одну роль");
            RuleForEach(command => command.Roles).IsInEnum().WithMessage("Введено неверное значение");
        }
        private bool IsEmailUnique(UpdateUserCommand command, string email)
        {
            return (_userManager.Users.FirstOrDefault(u => u.Email == email && u.Id != command.Id) != null) ? false : true;
        }
    }
}
