using FluentValidation;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class ChangePasswordValidator: AbstractValidator<UserChangePasswordViewModel>
    {
        public ChangePasswordValidator(LocalizationService<UserResource> localizer, IUserService userService)
        {
            RuleFor(x => x.CurrentPassword)
                .Must((reg, x) => userService.IsCurrentPassword(reg.Id, reg.CurrentPassword))
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_CurrentPasswordNotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"))
                .WithMessage(localizer.GetLocalizedString("msg_CurrentPassword"));
            
            RuleFor(x => x.NewPassword)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_NewPasswordNotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"));

            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_ConfirmPasswordNotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_ValidPassword"))
                .WithMessage(localizer.GetLocalizedString("msg_ConfirmPassword"));
        }
        
    }
}