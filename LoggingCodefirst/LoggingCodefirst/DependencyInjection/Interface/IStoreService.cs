using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.Store;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IStoreService
    {
        IEnumerable<Store> Stores { get; }
        
        Task<List<StoreViewModel>> GetListStoreAsync();
        Task<bool> CreateStoreAsync(StoreViewModel storeCreateModel);
        Task<StoreEditViewModel> GetStoreEditAsync(int? id);
        Task<bool> StoreEditAsync(StoreEditViewModel storeEditModel);
        Task<bool> DeleteStoreAsync(int? id);
        Task<StoreChangeEmailViewModel> GetChangeEmailAsync(int? id);
        Task<bool> ChangeEmailAsync(StoreChangeEmailViewModel changeEmailViewModel);
    }//end of interface
}