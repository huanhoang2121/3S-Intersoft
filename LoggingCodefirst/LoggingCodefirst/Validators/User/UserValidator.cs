using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels.User;

namespace LoggingCodefirst.Validators.User
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator(LocalizationService localizer, IUserService userService)
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
            
            RuleFor(x => x.Password)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"))
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$").WithMessage(localizer.GetLocalizedString("msg_vld_Password."));
            
            RuleFor(x => x.Fullname)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .MinimumLength(8).WithMessage(localizer.GetLocalizedString("msg_vld_8Characters"));
        }
    }
}