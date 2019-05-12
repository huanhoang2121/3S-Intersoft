using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Validators
{
    public class CategoryValidator: AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator(LocalizationService localizer, ICategoryService categoryService)
        {
            var categories = categoryService.Categories;
            foreach (var category in categories)
            {
                RuleFor(x => x.CategoryName).NotEqual(category.CategoryName).WithMessage(category.CategoryName + localizer.GetLocalizedString("msg_vld_Exists"));
            }
            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer.GetLocalizedString("msg_vld_NotEmpty"));
        }
        
    }
}