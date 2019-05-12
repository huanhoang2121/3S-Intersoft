using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class BrandValidator: AbstractValidator<BrandViewModel>
    {
        public BrandValidator(LocalizationService localizer, IBrandService brandService)
        {
            var brands = brandService.Brands;
            foreach (var brand in brands)
            {
                RuleFor(x => x.BrandName)
                    .NotEqual(brand.BrandName).WithMessage(brand.BrandName + localizer.GetLocalizedString("msg_vld_Exists"));
            }
            RuleFor(x => x.BrandName)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}