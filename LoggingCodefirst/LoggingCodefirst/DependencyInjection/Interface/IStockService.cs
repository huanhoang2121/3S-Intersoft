using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IStockService
    {
        IEnumerable<Stock> Stocks { get; }
        
        Task<List<StockViewModel>> GetListStockAsync();
        Task<bool> CreateStockAsync(StockViewModel stockCreateViewModel);
        Task<StockViewModel> GetStockEditAsync(int? productid, int? storeid);
        Task<bool> EditStockAsync(StockViewModel stockEditViewModel);
        Task<bool> DeleteStockAsync(int? productid, int? storeid);
    }//end of interface
}