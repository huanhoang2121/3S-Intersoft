using FluentValidation;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    { 
        public LoginValidator(ILocalizationService<UserResource> localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer.GetLocalizedString("msg_EmailNotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_ValidEmail"));
            
            RuleFor(x => x.Password).NotNull().WithMessage(localizer.GetLocalizedString("msg_PasswordNotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"));
        }
    }
}