using AutoMapper;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.ViewModels.StoreViewModels
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreIndexViewModel>();
            CreateMap<Store, StoreEditViewModel>();
        }
    }
}