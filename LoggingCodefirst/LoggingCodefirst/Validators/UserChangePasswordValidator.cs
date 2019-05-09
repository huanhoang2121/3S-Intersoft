using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class UserChangePasswordValidator: AbstractValidator<UserChangePasswordViewModel>
    {
        public UserChangePasswordValidator(LocalizationService localizer)
        {
            RuleFor(x => x.NewPassword).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."))
                .MinimumLength(6).WithMessage(localizer.GetLocalizedString("{PropertyName} cannot be less than 6 characters."))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("{PropertyName} must contain both letters and numbers."));

            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword)
                .WithMessage(localizer.GetLocalizedString("Incorrect confirm password!"));
        }
        
    }
}