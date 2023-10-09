using Application.Interfaces;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace Application.AppUsers.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandValidator(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;

            RuleFor(command => command.DisplayName).NotEmpty();
            RuleFor(command => command.UserName).NotEmpty().Must(IsUsernameUnique!)
                .WithMessage("Пользователь с таким логином уже зарегистирован");
            RuleFor(command => command.Age).NotEmpty().GreaterThan(0)
                .WithMessage("Возраст должен быть больше нуля");
            RuleFor(command => command.Email).NotEmpty().Must(IsEmailUnique!)
                .WithMessage("Пользователь с таким email уже зарегистрирован");
            RuleFor(command => command.Password).NotEmpty();
        }

        private bool IsEmailUnique(string email)
        {
            return (_userManager.Users.FirstOrDefault(u => u.Email == email) != null) ? false : true;
        }

        private bool IsUsernameUnique(string username)
        {
            return (_userManager.Users.FirstOrDefault(u => u.UserName == username) != null) ? false : true;
        }
    }
}
