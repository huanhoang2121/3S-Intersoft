using FluentValidation;
using LoggingCodefirst.ViewModels.StoreViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Store
{
    public class StoreEditValidator: AbstractValidator<StoreEditViewModel>
    {
        public StoreEditValidator(IStringLocalizer<StoreEditValidator> localizer)
        {
            RuleFor(x => x.StoreName).NotNull().WithMessage(localizer["Store name must not be empty."]);
            
            RuleFor(x => x.Phone).NotNull().WithMessage(localizer["Phone must not be empty."]);
        }
        
    }
}