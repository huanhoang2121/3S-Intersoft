using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Services.Interface
{
    public interface IBrandService
    {
        IEnumerable<Brand> Brands();
        Task<List<BrandViewModel>> GetListBrandAsync();
        Task<bool> CreateBrandAsync(BrandViewModel brandViewModel);
        Task<BrandViewModel> GetBrandEditAsync(int id);
        Task<bool> EditBrandAsync(BrandViewModel brandViewModel);
        Task<bool> DeleteBrandAsync(int id);
        bool IsExistedName(int id, string name);
    }//end of interface
}