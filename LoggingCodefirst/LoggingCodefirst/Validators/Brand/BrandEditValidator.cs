using System.Linq;
using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels.BrandViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Brand
{
    public class BrandEditValidator: AbstractValidator<BrandEditViewModel>
    {
        public BrandEditValidator(IStringLocalizer<BrandEditValidator> localizer, IBrandService brandService)
        {
            var brands = brandService.Brands.ToList();
            foreach (var brand in brands)
            {
                RuleFor(x => x.BrandName).NotEqual(brand.BrandName).WithMessage(localizer["This brand already exists."]);
            }
            RuleFor(x => x.BrandName).NotNull().WithMessage(localizer["Brand name must not be empty."]);
        }
        
    }
}