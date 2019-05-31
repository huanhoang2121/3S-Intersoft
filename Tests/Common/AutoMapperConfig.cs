using AutoMapper;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace Tests.Common
{
    public class AutoMapperConfig
    {
        private static readonly object ThisLock = new object();
        private static bool _initialized;

        private static IMapper _mapper;
        // Centralize automapper initialize
        public static void Initialize()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized
            lock (ThisLock)
            {
                if (!_initialized)
                {
                    var config = new MapperConfiguration(opts =>
                    {
//                        Map for Brand
                        opts.CreateMap<Brand, BrandViewModel>();  
//                        Map for Category         
                        opts.CreateMap<Category, CategoryViewModel>();
//                        Map for Product
                        opts.CreateMap<Product, ProductViewModel>();
//                        Map for Stock
                        opts.CreateMap<Stock, StockViewModel>();
//                        Map for Store
                        opts.CreateMap<Store, StoreViewModel>();
//                        Map for User
                        opts.CreateMap<User, UserViewModel>();
                        opts.CreateMap<User, UserEditViewModel>();
                        opts.CreateMap<User, UserChangePasswordViewModel>();
                    });
                    _initialized = true;
                    _mapper = config.CreateMapper();
                }
            }
        }

        public static IMapper GetMapper()
        {
            return _mapper;
        }
    }
}