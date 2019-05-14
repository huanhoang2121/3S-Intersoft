using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.User;

namespace LoggingCodefirst.Validators.User
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    { 
        public LoginValidator(LocalizationService localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_vld_ValidEmail"));
            RuleFor(x => x.Password).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"));
        }
    }
}