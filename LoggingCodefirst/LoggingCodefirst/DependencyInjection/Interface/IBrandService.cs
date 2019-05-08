using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels.BrandViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IBrandService
    {
        IEnumerable<Brand> Brands { get; }
        
        Task<List<BrandIndexViewModel>> GetListBrandAsync();
        Task<bool> CreateBrandAsync(BrandCreateViewModel brandCreateViewModel);
        Task<BrandEditViewModel> GetBrandEditAsync(int? id);
        Task<bool> EditBrandAsync(BrandEditViewModel brandEditViewModel);
        Task<bool> DeleteBrandAsync(int? id);
    }//end of interface
}