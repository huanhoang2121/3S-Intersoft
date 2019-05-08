using AutoMapper;
using LoggingCodefirst.Models.Production;

namespace LoggingCodefirst.ViewModels.BrandViewModels
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandIndexViewModel>();
            CreateMap<Brand, BrandEditViewModel>();
        }
    }
}