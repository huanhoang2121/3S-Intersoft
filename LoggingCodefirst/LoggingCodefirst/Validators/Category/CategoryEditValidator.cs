using System.Linq;
using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels.CategoryViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Category
{
    public class CategoryEditValidator: AbstractValidator<CategoryEditViewModel>
    {
        public CategoryEditValidator(IStringLocalizer<CategoryEditValidator> localizer, ICategoryService categoryService)
        {
            var categories = categoryService.Categories.ToList();
            foreach (var category in categories)
            {
                RuleFor(x => x.CategoryName).NotEqual(category.CategoryName).WithMessage(localizer["This category already exists."]);
            }
            RuleFor(x => x.CategoryName).NotNull().WithMessage(localizer["Category name must not be empty."]);
        }
        
    }
}