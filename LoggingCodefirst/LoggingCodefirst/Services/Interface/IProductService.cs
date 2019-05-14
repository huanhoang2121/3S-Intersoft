using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Services.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> Products();        
        Task<List<ProductViewModel>> GetListProductAsync();
        Task<bool> CreateProductAsync(ProductViewModel productCreateViewModel);
        Task<ProductViewModel> GetProductEditAsync(int id);
        Task<bool> EditProductAsync(ProductViewModel productEditViewModel);
        Task<bool> DeleteProductAsync(int id);
    }//end of interface
}