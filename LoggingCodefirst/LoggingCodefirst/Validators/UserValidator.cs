﻿using System.Linq;
using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator(LocalizationService localizer, IUserService userService)
        {
            var users = userService.Users.ToList();
            
            RuleFor(x => x.Email).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer.GetLocalizedString("Enter a valid email address."));
            
            foreach (var user in users)
            {
                RuleFor(x => x.Email).NotEqual(user.Email).WithMessage(user.Email + localizer.GetLocalizedString(" already exists."));
            }
            
            RuleFor(x => x.Password).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."));
            RuleFor(x => x.Password).MinimumLength(8).WithMessage(localizer.GetLocalizedString("{PropertyName} cannot be less than 8 characters."));
            RuleFor(x => x.Password).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("{PropertyName} must contain both letters and numbers."));
            
            RuleFor(x => x.Fullname).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."));
            RuleFor(x => x.Fullname).MinimumLength(8).WithMessage(localizer.GetLocalizedString("{PropertyName} cannot be less than 8 characters."));
        }
    }
}