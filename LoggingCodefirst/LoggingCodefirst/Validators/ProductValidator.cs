using FluentValidation;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class ProductValidator: AbstractValidator<ProductViewModel>
    {
        public ProductValidator(LocalizationService<ViewResource> localizer)
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
            RuleFor(x => x.ListPrice).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
            RuleFor(x => x.ModelYear).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}