using FluentValidation;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class ChangePasswordValidator: AbstractValidator<UserChangePasswordViewModel>
    {
        public ChangePasswordValidator(LocalizationService<UserResource> localizer)
        {
            RuleFor(x => x.NewPassword).NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"));

            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword)
                .WithMessage(localizer.GetLocalizedString("msg_ConfirmPassword"));
        }
        
    }
}