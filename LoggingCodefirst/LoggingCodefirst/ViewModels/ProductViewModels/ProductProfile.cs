using AutoMapper;
using LoggingCodefirst.Models.Production;

namespace LoggingCodefirst.ViewModels.ProductViewModels
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductIndexViewModel>();
            CreateMap<Product, ProductEditViewModel>();
        }
    }
}