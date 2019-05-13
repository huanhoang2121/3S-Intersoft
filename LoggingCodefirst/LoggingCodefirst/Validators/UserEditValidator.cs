using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.User;

namespace LoggingCodefirst.Validators
{
    public class UserEditValidator : AbstractValidator<UserEditViewModel>
    {
        public UserEditValidator(LocalizationService localizer)
        {
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"));
        }
    }
}