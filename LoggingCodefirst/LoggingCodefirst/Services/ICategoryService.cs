using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> Categories();        
        Task<List<CategoryViewModel>> GetListCategoryAsync();
        Task<bool> CreateCategoryAsync(CategoryViewModel categoryCreateViewModel);
        Task<CategoryViewModel> GetCategoryEditAsync(int id);
        Task<bool> EditCategoryAsync(CategoryViewModel categoryEditViewModel);
        Task<bool> DeleteCategoryAsync(int id);
        bool IsExistedName(int id, string name);
    }//end of interface
}