﻿using System;
using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services.Interface;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator(LocalizationService localizer, IUserService userService)
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_vld_ValidEmail"))
                .Must((reg, x) => !userService.IsExistedEmail(reg.Id, reg.Email)).WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_vld_Exists"), x));
            
            RuleFor(x => x.Password)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_vld_Password."));
            
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"));
        }
    }
}