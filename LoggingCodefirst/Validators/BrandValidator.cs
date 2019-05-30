using FluentValidation;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class BrandValidator: AbstractValidator<BrandViewModel>
    {
        public BrandValidator(LocalizationService<BrandResource> localizer, IBrandService brandService)
        {
            RuleFor(x => x.BrandName)
                .Must((reg, x) => !brandService.IsExistedName(reg.Id,reg.BrandName))
                .WithMessage((reg, x) => string.Format(localizer.GetLocalizedString("msg_Exists"), x));
            RuleFor(x => x.BrandName)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"));
        }
        
    }
}