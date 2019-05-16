using System;
using FluentValidation;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class BrandValidator: AbstractValidator<BrandViewModel>
    {
        public BrandValidator(LocalizationService<ViewResource> localizer, IBrandService brandService)
        {
            RuleFor(x => x.BrandName)
                .Must((reg, x) => !brandService.IsExistedName(reg.Id,reg.BrandName))
                .WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_vld_Exists"), x));
            RuleFor(x => x.BrandName)
                .NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}