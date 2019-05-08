using FluentValidation;
using LoggingCodefirst.ViewModels.UserViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.User
{
    public class UserChangePasswordValidator: AbstractValidator<UserChangePasswordViewModel>
    {
        public UserChangePasswordValidator(IStringLocalizer<UserChangePasswordValidator> localizer)
        {
            RuleFor(x => x.OldPassword).NotNull().WithMessage(localizer["Password must not be empty."])
                .MinimumLength(6).WithMessage(localizer["Password cannot be less than 6 characters."])
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer["Password must contain both letters and numbers."]);
            
            RuleFor(x => x.NewPassword).NotNull().WithMessage(localizer["Password must not be empty."])
                .MinimumLength(6).WithMessage(localizer["Password cannot be less than 6 characters."])
                .Matches(@"^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer["Password must contain both letters and numbers."]);
        }
        
    }
}