using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Interface
{
    public interface ICategoryService
    {
        
        #region Public Methods

        /// <summary>
        /// Get Categories
        /// </summary>
        /// <returns>Categories</returns>
        IEnumerable<Category> Categories();  
        
        /// <summary>
        /// GetListCategoryAsync
        /// </summary>
        /// <returns>ListCategory</returns>
        Task<List<CategoryViewModel>> GetListCategoryAsync();
        
        /// <summary>
        /// CreateCategoryAsync
        /// </summary>
        /// <param name="categoryCreateViewModel">CategoryViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateCategoryAsync(CategoryViewModel categoryCreateViewModel);
        
        /// <summary>
        /// GetCategoryEditAsync
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>CategoryViewModel</returns>
        Task<CategoryViewModel> GetCategoryEditAsync(int id);
        
        /// <summary>
        /// EditCategoryAsync
        /// </summary>
        /// <param name="createViewModel">CategoryViewModel</param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditCategoryAsync(CategoryViewModel createViewModel);
        
        /// <summary>
        /// DeleteCategoryAsync
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteCategoryAsync(int id);
        
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="id">Category id</param>
        /// <param name="name">Category name</param>
        /// <returns>ExistedName</returns>
        bool IsExistedName(int id, string name);
        
        #endregion

    }//end of interface
}