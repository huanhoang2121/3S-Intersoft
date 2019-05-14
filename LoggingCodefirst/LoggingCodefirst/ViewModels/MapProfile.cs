using AutoMapper;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels.Store;
using LoggingCodefirst.ViewModels.User;

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
            CreateMap<Models.Store, StoreViewModel>();
            CreateMap<Models.Store, StoreEditViewModel>();
            CreateMap<Models.Store, StoreChangeEmailViewModel>();
//            Map for User
            CreateMap<Models.User, UserViewModel>();
            CreateMap<Models.User, UserEditViewModel>();
            CreateMap<Models.User, UserChangeEmailViewModel>();
            CreateMap<Models.User, UserChangePasswordViewModel>();
        }
    }
}