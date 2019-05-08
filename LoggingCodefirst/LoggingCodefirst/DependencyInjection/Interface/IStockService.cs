using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels.StockViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IStockService
    {
        IEnumerable<Stock> Stocks { get; }
        
        Task<List<StockIndexViewModel>> GetListStockAsync();
        Task<bool> CreateStockAsync(StockCreateViewModel stockCreateViewModel);
        Task<StockEditViewModel> GetStockEditAsync(int? productid, int? storeid);
        Task<bool> EditStockAsync(StockEditViewModel stockEditViewModel);
        Task<bool> DeleteStockAsync(int? productid, int? storeid);
    }//end of interface
}