using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> Products { get; } 
        
        Task<List<ProductViewModel>> GetListProductAsync();
        Task<bool> CreateProductAsync(ProductViewModel productCreateViewModel);
        Task<ProductViewModel> GetProductEditAsync(int? id);
        Task<bool> EditProductAsync(ProductViewModel productEditViewModel);
        Task<bool> DeleteProductAsync(int? id);
    }//end of interface
}