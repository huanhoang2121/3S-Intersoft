﻿using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels.User;

namespace LoggingCodefirst.Validators.User
{
    public class ChangePasswordValidator: AbstractValidator<UserChangePasswordViewModel>
    {
        public ChangePasswordValidator(LocalizationService localizer)
        {
            RuleFor(x => x.NewPassword).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_vld_Password"));

            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword)
                .WithMessage(localizer.GetLocalizedString("msg_vld_ConfirmPassword"));
        }
        
    }
}