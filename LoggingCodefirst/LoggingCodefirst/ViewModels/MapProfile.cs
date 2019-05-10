using AutoMapper;
using LoggingCodefirst.Models;

namespace LoggingCodefirst.ViewModels
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Brand, BrandViewModel>();            
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Stock, StockViewModel>();
            CreateMap<Store, StoreViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserChangePasswordViewModel>();
        }
    }
}