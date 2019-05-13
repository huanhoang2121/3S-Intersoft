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
            CreateMap<Brand, BrandViewModel>();            
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Stock, StockViewModel>();
            CreateMap<Models.Store, StoreViewModel>();
            CreateMap<Models.Store, StoreEditViewModel>();
            CreateMap<Models.Store, StoreChangeEmailViewModel>();
            CreateMap<Models.User, UserViewModel>();
            CreateMap<Models.User, UserEditViewModel>();
            CreateMap<Models.User, UserChangeEmailViewModel>();
            CreateMap<Models.User, UserChangePasswordViewModel>();
        }
    }
}