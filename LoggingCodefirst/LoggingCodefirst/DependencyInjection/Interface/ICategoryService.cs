using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels.CategoryViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface ICategoryService
    {
        IEnumerable<Category> Categories { get; }
        
        Task<List<CategoryIndexViewModel>> GetListCategoryAsync();
        Task<bool> CreateCategoryAsync(CategoryCreateViewModel categoryCreateViewModel);
        Task<CategoryEditViewModel> GetCategoryEditAsync(int? id);
        Task<bool> EditCategoryAsync(CategoryEditViewModel categoryEditViewModel);
        Task<bool> DeleteCategoryAsync(int? id);
    }//end of interface
}