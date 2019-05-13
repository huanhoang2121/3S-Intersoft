using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.Store;

namespace LoggingCodefirst.Validators
{
    public class StoreChangeEmailValidator: AbstractValidator<StoreChangeEmailViewModel>
    {
        public StoreChangeEmailValidator(LocalizationService localizer, IStoreService storeService)
        {
            var stores = storeService.Stores;
            RuleFor(x => x.Email)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("msg_vld_ValidEmail"));
            
            foreach (var store in stores)
            {
                RuleFor(x => x.Email)
                    .NotEqual(store.Email).WithMessage(store.Email + localizer.GetLocalizedString("msg_vld_Exists"));
            }
        }
        
    }
}