using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Interface
{
    public interface IBrandService
    {
        
        #region Public Methods
        
        /// <summary>
        /// Get Brands
        /// </summary>
        /// <returns>Brands</returns>
        IEnumerable<BrandViewModel> GetBrands();
        
        /// <summary>
        /// CreateBrandAsync
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateBrandAsync(BrandViewModel brandViewModel);
        
        /// <summary>
        /// GetBrandEditAsync
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <returns>Brand</returns>
        Task<BrandViewModel> GetBrandEditAsync(int id);
        
        /// <summary>
        /// EditBrandAsync
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditBrandAsync(BrandViewModel brandViewModel);
        
        /// <summary>
        /// DeleteBrandAsync
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteBrandAsync(int id);
        
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <param name="name">Brand name</param>
        /// <returns>ExistedName</returns>
        bool IsExistedName(int id, string name);
        
        #endregion
        
    }//end of interface
}