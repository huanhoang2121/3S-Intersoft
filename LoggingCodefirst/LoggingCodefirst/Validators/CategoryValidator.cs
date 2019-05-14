using System;
using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services.Interface;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class CategoryValidator: AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator(LocalizationService localizer, ICategoryService categoryService)
        {
            RuleFor(x => x.CategoryName)
                .Must((reg, x) => !categoryService.IsExistedName(reg.Id,reg.CategoryName))
                .WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_vld_Exists"), x));
            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}