using System.Linq;
using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels.UserViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.User
{
    public class UserCreateValidator : AbstractValidator<UserCreateViewModel>
    {
        public UserCreateValidator(IStringLocalizer<UserCreateValidator> localizer, IUserService userService)
        {
            var users = userService.Users.ToList();
            
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email must not be empty."]);
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizer["Enter a valid email address."]);
            
            foreach (var user in users)
            {
                RuleFor(x => x.Email).NotEqual(user.Email).WithMessage(localizer["This email already exists."]);
            }
            
            RuleFor(x => x.Password).NotNull().WithMessage(localizer["Password must not be empty."]);
            RuleFor(x => x.Password).MinimumLength(6).WithMessage(localizer["Password cannot be less than 6 characters."]);
            RuleFor(x => x.Password).Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer["Password must contain both letters and numbers."]);
            
            RuleFor(x => x.Fullname).NotNull().WithMessage(localizer["Fullname must not be empty."]);
            RuleFor(x => x.Fullname).MinimumLength(10).WithMessage(localizer["Fullname cannot be less than 10 characters."]);
        }
        
    }
}