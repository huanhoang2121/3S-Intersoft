using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface ICategoryService
    {
        IEnumerable<Category> Categories { get; }
        
        Task<List<CategoryViewModel>> GetListCategoryAsync();
        Task<bool> CreateCategoryAsync(CategoryViewModel categoryCreateViewModel);
        Task<CategoryViewModel> GetCategoryEditAsync(int? id);
        Task<bool> EditCategoryAsync(CategoryViewModel categoryEditViewModel);
        Task<bool> DeleteCategoryAsync(int? id);
    }//end of interface
}