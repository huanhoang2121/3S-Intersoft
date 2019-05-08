using FluentValidation;
using LoggingCodefirst.ViewModels.UserViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.User
{
    public class UserEditValidator: AbstractValidator<UserEditViewModel>
    {
        public UserEditValidator(IStringLocalizer<UserEditValidator> localizer)
        {
            RuleFor(x => x.Fullname).NotNull().WithMessage(localizer["Fullname must not be empty."]);
            RuleFor(x => x.Fullname).MinimumLength(10).WithMessage(localizer["Fullname cannot be less than 10 characters."]);
        }
        
    }
}