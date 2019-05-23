using System;
using FluentValidation;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class CategoryValidator: AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator(LocalizationService<CategoryResource> localizer, ICategoryService categoryService)
        {
            RuleFor(x => x.CategoryName)
                .Must((reg, x) => !categoryService.IsExistedName(reg.Id,reg.CategoryName))
                .WithMessage((reg, x) => String.Format(localizer.GetLocalizedString("msg_Exists"), x));
            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer.GetLocalizedString("msg_NotEmpty"));
        }
        
    }
}