using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Interface
{
    public interface IStoreService
    {
        
        #region Public Methods
        
        /// <summary>
        /// Stores
        /// </summary>
        /// <returns>Stores</returns>
        IEnumerable<Store> Stores();        
        
        /// <summary>
        /// GetListStoreAsync
        /// </summary>
        /// <returns>ListStore</returns>
        Task<List<StoreViewModel>> GetListStoreAsync();
        
        /// <summary>
        /// CreateStoreAsync
        /// </summary>
        /// <param name="createViewModel">StoreViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateStoreAsync(StoreViewModel createViewModel);
        
        /// <summary>
        /// GetStoreEditAsync
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>StoreViewModel</returns>
        Task<StoreViewModel> GetStoreEditAsync(int id);
        
        /// <summary>
        /// StoreEditAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
        Task<bool> StoreEditAsync(StoreViewModel editViewModel);
        
        /// <summary>
        /// DeleteStoreAsync
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteStoreAsync(int id);
        
        /// <summary>
        /// IsExistedEmail
        /// </summary>
        /// <param name="id">Store id</param>
        /// <param name="name">Store name</param>
        /// <returns>ExistedName</returns>
        bool IsExistedEmail(int id, string name);
        
        #endregion
        
    }//end of interface
}