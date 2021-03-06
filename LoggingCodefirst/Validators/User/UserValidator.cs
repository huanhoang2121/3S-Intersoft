﻿using FluentValidation;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator(ILocalizationService<UserResource> localizer, IUserService userService)
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_EmailNotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_ValidEmail"))
                .Must((reg, x) => !userService.IsExistedEmail(reg.Id, reg.Email))
                .WithMessage((reg, x) => string.Format(localizer.GetLocalizedString("msg_Exists"), x));
            
            RuleFor(x => x.Password)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_PasswordNotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"));
            
            RuleFor(x => x.ConfirmPassword)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_PasswordNotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"))
                .Equal(x => x.Password).WithMessage(localizer.GetLocalizedString("msg_ConfirmPassword"));
            
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_FullNameNotEmpty"));
        }
    }
}