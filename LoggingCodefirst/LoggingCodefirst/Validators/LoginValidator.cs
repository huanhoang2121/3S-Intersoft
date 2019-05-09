using FluentValidation;
using LoggingCodefirst.ViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    { 
        public LoginValidator(IStringLocalizer<LoginValidator> localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email must not be empty."])
                .EmailAddress().WithMessage(localizer["Enter a valid email address."]);
            RuleFor(x => x.Password).NotNull().WithMessage(localizer["Password must not be empty."])
                .MinimumLength(8).WithMessage(localizer["Password cannot be less than 8 characters."]);
        }
    }
}