using System;
using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator(LocalizationService<UserResource> localizer, IUserService userService)
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_ValidEmail"))
                .Must((reg, x) => !userService.IsExistedEmail(reg.Id, reg.Email))
                .WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_Exists"), x));
            
            RuleFor(x => x.Password)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"));
            
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"));
        }
    }
}