using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels.User;

namespace LoggingCodefirst.Validators.User
{
    public class ChangeEmailValidator: AbstractValidator<UserChangeEmailViewModel>
    {
        public ChangeEmailValidator(LocalizationService localizer, IUserService userService)
        {
            var users = userService.Users;
            RuleFor(x => x.Email)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_vld_ValidEmail"));
            
            foreach (var user in users)
            {
                RuleFor(x => x.Email)
                    .NotEqual(user.Email).WithMessage(user.Email + localizer.GetLocalizedString("msg_vld_Exists"));
            }
        }
        
    }
}