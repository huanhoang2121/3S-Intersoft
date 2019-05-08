using FluentValidation;
using LoggingCodefirst.ViewModels.ProductViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Product
{
    public class ProductEditValidator: AbstractValidator<ProductEditViewModel>
    {
        public ProductEditValidator(IStringLocalizer<ProductEditValidator> localizer)
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage(localizer["Product Name must not be empty."]);
            RuleFor(x => x.ListPrice).NotNull().WithMessage(localizer["List Price must not be empty."]);
            RuleFor(x => x.ModelYear).NotNull().WithMessage(localizer["Model Year must not be empty."]);
        }
        
    }
}