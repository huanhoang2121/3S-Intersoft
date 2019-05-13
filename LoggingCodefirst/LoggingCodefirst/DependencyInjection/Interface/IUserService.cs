using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.User;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IUserService
    {
        IEnumerable<User> Users { get; } 
        
        bool Login(LoginViewModel loginViewModel);
        Task<User> GetUserNameAsync(string email);
        
        Task<List<UserViewModel>> GetListUserAsync();
        Task<bool> CreateUserAsync(UserViewModel userCreate);
        Task<UserEditViewModel> GetUserEditAsync(int? id);
        Task<bool> EditUserAsync(UserEditViewModel userEdit);
        Task<bool> DeleteUserAsync(int? id);
        Task<UserChangePasswordViewModel> GetChangePasswordAsync(int? id);
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordModel);
        Task<UserChangeEmailViewModel> GetChangeEmailAsync(int? id);
        Task<bool> ChangeEmailAsync(UserChangeEmailViewModel changeEmailViewModel);
    }//end of interface
}