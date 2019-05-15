using System;
using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StoreValidator: AbstractValidator<StoreViewModel>
    {
        public StoreValidator(LocalizationService<ViewResource> localizer, IStoreService storeService)
        {
            RuleFor(x => x.Email)
                .Must((reg, x) => !storeService.IsExistedEmail(reg.Id,reg.Email))
                .WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_vld_Exists"), x))
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_vld_ValidEmail"));
            
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}