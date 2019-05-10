using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IBrandService
    {
        IEnumerable<Brand> Brands { get; }
        
        Task<List<BrandViewModel>> GetListBrandAsync();
        Task<bool> CreateBrandAsync(BrandViewModel brandViewModel);
        Task<BrandViewModel> GetBrandEditAsync(int? id);
        Task<bool> EditBrandAsync(BrandViewModel brandViewModel);
        Task<bool> DeleteBrandAsync(int? id);
    }//end of interface
}