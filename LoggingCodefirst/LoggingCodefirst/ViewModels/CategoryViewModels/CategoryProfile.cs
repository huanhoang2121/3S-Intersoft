using AutoMapper;
using LoggingCodefirst.Models.Production;

namespace LoggingCodefirst.ViewModels.CategoryViewModels
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryIndexViewModel>();
            CreateMap<Category, CategoryEditViewModel>();
        }
    }
}