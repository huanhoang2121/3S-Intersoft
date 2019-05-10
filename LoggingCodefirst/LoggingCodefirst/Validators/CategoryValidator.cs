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
                RuleFor(x => x.CategoryName).NotEqual(category.CategoryName).WithMessage(category.CategoryName + localizer.GetLocalizedString(" already exists."));
            }
            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer.GetLocalizedString("{PropertyName} must not be empty."));
        }
        
    }
}