using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IUserService
    {
        IEnumerable<User> Users { get; } 
        
        bool Login(LoginViewModel loginViewModel);
        Task<User> GetUserNameAsync(string email);
        
        Task<List<UserViewModel>> GetListUserAsync();
        Task<bool> CreateUserAsync(UserViewModel userCreate);
        Task<UserViewModel> GetUserEditAsync(int? id);
        Task<bool> EditUserAsync(UserViewModel userEdit);
        Task<bool> DeleteUserAsync(int? id);
        Task<UserChangePasswordViewModel> GetChangePasswordAsync(int? id);
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordModel);
    }//end of interface
}