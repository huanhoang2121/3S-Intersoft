using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.Store;

namespace LoggingCodefirst.Validators
{
    public class StoreValidator: AbstractValidator<StoreViewModel>
    {
        public StoreValidator(LocalizationService localizer, IStoreService storeService)
        {
            var stores = storeService.Stores;
            foreach (var store in stores)
            {
                RuleFor(x => x.Email).NotEqual(store.Email).WithMessage(store.StoreName + localizer.GetLocalizedString("msg_vld_Exists"));
            }
            
            RuleFor(x => x.Email).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_vld_ValidEmail"));
            
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}