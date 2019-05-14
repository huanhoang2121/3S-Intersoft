using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels.User;

namespace LoggingCodefirst.Validators.User
{
    public class EditValidator : AbstractValidator<UserEditViewModel>
    {
        public EditValidator(LocalizationService localizer)
        {
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"));
        }
    }
}