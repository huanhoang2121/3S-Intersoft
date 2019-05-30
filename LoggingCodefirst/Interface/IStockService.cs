using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Interface
{
    public interface IStockService
    {
        
        #region Public Methods

        /// <summary>
        /// Get Stocks
        /// </summary>
        /// <returns>Stocks</returns>
        IEnumerable<StockViewModel> GetStocks();      
        
        /// <summary>
        /// CreateStockAsync
        /// </summary>
        /// <param name="createViewModel">StockViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateStockAsync(StockViewModel createViewModel);
        
        /// <summary>
        /// GetStockEditAsync
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>StockViewModel</returns>
        Task<StockViewModel> GetStockEditAsync(int productid, int storeid);
        
        /// <summary>
        /// EditStockAsync
        /// </summary>
        /// <param name="editViewModel">StockViewModel</param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditStockAsync(StockViewModel editViewModel);
        
        /// <summary>
        /// DeleteStockAsync
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteStockAsync(int productid, int storeid);
        
        #endregion

    }//end of interface
}