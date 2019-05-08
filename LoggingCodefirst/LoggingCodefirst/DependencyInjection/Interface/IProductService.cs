using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels.ProductViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> Products { get; } 
        
        Task<List<ProductIndexViewModel>> GetListProductAsync();
        Task<bool> CreateProductAsync(ProductCreateViewModel productCreateViewModel);
        Task<ProductEditViewModel> GetProductEditAsync(int? id);
        Task<bool> EditProductAsync(ProductEditViewModel productEditViewModel);
        Task<bool> DeleteProductAsync(int? id);
    }//end of interface
}