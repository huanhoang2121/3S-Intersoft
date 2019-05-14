using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Services.Interface
{
    public interface IStoreService
    {
        IEnumerable<Store> Stores();        
        Task<List<StoreViewModel>> GetListStoreAsync();
        Task<bool> CreateStoreAsync(StoreViewModel storeCreateModel);
        Task<StoreViewModel> GetStoreEditAsync(int id);
        Task<bool> StoreEditAsync(StoreViewModel storeEditModel);
        Task<bool> DeleteStoreAsync(int id);
        bool IsExistedEmail(int id, string name);
    }//end of interface
}