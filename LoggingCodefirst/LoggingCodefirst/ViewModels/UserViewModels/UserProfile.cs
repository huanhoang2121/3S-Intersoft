using AutoMapper;
using LoggingCodefirst.Models.Sales;

namespace LoggingCodefirst.ViewModels.UserViewModels
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserIndexViewModel>();
            CreateMap<User, UserEditViewModel>();
        }
    }
}