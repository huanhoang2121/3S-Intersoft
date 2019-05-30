using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Interface
{
    public interface IProductService
    {
        
        #region Public Methods
        
        /// <summary>
        /// Products
        /// </summary>
        /// <returns>Products</returns>
        IEnumerable<ProductViewModel> GetProducts(); 
        
        /// <summary>
        /// CreateProductAsync
        /// </summary>
        /// <param name="createViewModel">ProductViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateProductAsync(ProductViewModel createViewModel);
        
        /// <summary>
        /// GetProductEditAsync
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>ProductViewModel</returns>
        Task<ProductViewModel> GetProductEditAsync(int id);
        
        /// <summary>
        /// EditProductAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditProductAsync(ProductViewModel editViewModel);
        
        /// <summary>
        /// DeleteProductAsync
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteProductAsync(int id);
        
        #endregion
        
    }//end of interface
}