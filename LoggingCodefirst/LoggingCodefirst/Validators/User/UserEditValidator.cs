﻿using System;
using FluentValidation;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class UserEditValidator : AbstractValidator<UserEditViewModel>
    {
        public UserEditValidator(LocalizationService<UserResource> localizer, IUserService userService)
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_ValidEmail"))
                .Must((reg, x) => !userService.IsExistedEmail(reg.Id, reg.Email))
                .WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_Exists"), x));
            
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"));
        }
    }
}