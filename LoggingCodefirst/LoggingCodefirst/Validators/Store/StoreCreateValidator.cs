using System.Linq;
using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels.StoreViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Store
{
    public class StoreCreateValidator: AbstractValidator<StoreCreateViewModel>
    {
        public StoreCreateValidator(IStringLocalizer<StoreCreateValidator> localizer, IStoreService storeService)
        {
            var stores = storeService.Stores.ToList();
            foreach (var store in stores)
            {
                RuleFor(x => x.Email).NotEqual(store.Email).WithMessage(localizer["This Email already exists."]);
            }
            
            RuleFor(x => x.Email).NotNull().WithMessage(localizer["Email must not be empty."])
                .EmailAddress().WithMessage(localizer["Enter a valid email address."]);
            
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer["Store name must not be empty."]);
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone must not be empty."]);
        }
        
    }
}