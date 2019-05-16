using System;
using FluentValidation;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StoreValidator: AbstractValidator<StoreViewModel>
    {
        public StoreValidator(LocalizationService<StoreResource> localizer, IStoreService storeService)
        {
            RuleFor(x => x.Email)
                .Must((reg, x) => !storeService.IsExistedEmail(reg.Id,reg.Email))
                .WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_Exists"), x))
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_EmailNotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_ValidEmail"));
            
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer.GetLocalizedString("msg_StoreNameNotEmpty"));
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer.GetLocalizedString("msg_PhoneNotEmpty"));
        }
        
    }
}