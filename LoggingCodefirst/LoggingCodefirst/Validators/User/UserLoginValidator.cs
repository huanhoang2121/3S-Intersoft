using FluentValidation;
using LoggingCodefirst.ViewModels.AccountViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.User
{
    public class UserLoginValidator : AbstractValidator<AccountLoginViewModel>
    { 
        public UserLoginValidator(IStringLocalizer<UserLoginValidator> localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email must not be empty."])
                .EmailAddress().WithMessage(localizer["Enter a valid email address."]);
            RuleFor(x => x.Password).NotNull().WithMessage(localizer["Password must not be empty."])
                .MinimumLength(8).WithMessage(localizer["Password cannot be less than 8 characters."]);
        }
    }
}