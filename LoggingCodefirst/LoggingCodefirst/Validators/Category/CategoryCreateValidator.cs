using System.Linq;
using FluentValidation;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels.CategoryViewModels;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Validators.Category
{
    public class CategoryCreateValidator: AbstractValidator<CategoryCreateViewModel>
    {
        public CategoryCreateValidator(IStringLocalizer<CategoryCreateValidator> localizer, ICategoryService categoryService)
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