using System.Linq;
using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class StoreValidator: AbstractValidator<StoreViewModel>
    {
        public StoreValidator(LocalizationService localizer, IStoreService storeService)
        {
            var stores = storeService.Stores.ToList();
            foreach (var store in stores)
            {
                RuleFor(x => x.Email).NotEqual(store.Email).WithMessage(store.StoreName + localizer.GetLocalizedString(" already exists."));
            }
            
            RuleFor(x => x.Email).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."))
                .EmailAddress().WithMessage(localizer.GetLocalizedString("Enter a valid email address."));
            
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."));
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."));
        }
        
    }
}