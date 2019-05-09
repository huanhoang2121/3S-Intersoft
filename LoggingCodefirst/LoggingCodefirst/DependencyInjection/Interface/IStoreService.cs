using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Sales;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IStoreService
    {
        IEnumerable<Store> Stores { get; }
        
        Task<List<StoreViewModel>> GetListStoreAsync();
        Task<bool> CreateStoreAsync(StoreViewModel storeCreateModel);
        Task<StoreViewModel> GetStoreEditAsync(int? id);
        Task<bool> StoreEditAsync(StoreViewModel storeEditModel);
        Task<bool> DeleteStoreAsync(int? id);
    }//end of interface
}