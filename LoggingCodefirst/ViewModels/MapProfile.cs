using AutoMapper;
using LoggingCodefirst.Models;

namespace LoggingCodefirst.ViewModels
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
//            Map for Brand
            CreateMap<Brand, BrandViewModel>();  
//            Map for Category         
            CreateMap<Category, CategoryViewModel>();
//            Map for Product
            CreateMap<Product, ProductViewModel>();
//            Map for Stock
            CreateMap<Stock, StockViewModel>();
//            Map for Store
            CreateMap<Store, StoreViewModel>();
//            Map for User
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserEditViewModel>();
            CreateMap<User, UserChangePasswordViewModel>();
        }
    }
}