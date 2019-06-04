using FluentValidation;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class ProductValidator: AbstractValidator<ProductViewModel>
    {
        public ProductValidator(ILocalizationService<ProductResource> localizer)
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage(localizer.GetLocalizedString("msg_ProductNameNotEmpty"));
            RuleFor(x => x.ListPrice).NotNull().WithMessage(localizer.GetLocalizedString("msg_ListPriceNotEmpty"));
//            RuleFor(x => x.ImageFile).NotNull().WithMessage(localizer.GetLocalizedString("msg_ImageFileNotEmpty"));
            RuleFor(x => x.ModelYear).NotNull().WithMessage(localizer.GetLocalizedString("msg_ModelYearNotEmpty"));
        }
        
    }
}