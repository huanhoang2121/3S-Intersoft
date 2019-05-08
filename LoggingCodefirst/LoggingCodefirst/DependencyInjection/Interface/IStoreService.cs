using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Sales;
using LoggingCodefirst.ViewModels.StoreViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IStoreService
    {
        IEnumerable<Store> Stores { get; }
        
        Task<List<StoreIndexViewModel>> GetListStoreAsync();
        Task<bool> CreateStoreAsync(StoreCreateViewModel storeCreateModel);
        Task<StoreEditViewModel> GetStoreEditAsync(int? id);
        Task<bool> StoreEditAsync(StoreEditViewModel storeEditModel);
        Task<bool> DeleteStoreAsync(int? id);
    }//end of interface
}