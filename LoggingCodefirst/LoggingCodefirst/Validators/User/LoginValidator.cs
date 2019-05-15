using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    { 
        public LoginValidator(LocalizationService<UserResource> localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_ValidEmail"));
            RuleFor(x => x.Password).NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"));
        }
    }
}