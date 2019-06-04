using FluentValidation;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators.User
{
    public class UserEditValidator : AbstractValidator<UserEditViewModel>
    {
        public UserEditValidator(ILocalizationService<UserResource> localizer, IUserService userService)
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_EmailNotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_ValidEmail"))
                .Must((reg, x) => !userService.IsExistedEmail(reg.Id, reg.Email))
                .WithMessage((reg, x) => string.Format(localizer.GetLocalizedString("msg_Exists"), x));
            
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_FullNameNotEmpty"));
        }
    }
}