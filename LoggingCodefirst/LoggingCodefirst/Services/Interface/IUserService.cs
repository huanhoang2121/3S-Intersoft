using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Services.Interface
{
    public interface IUserService
    {
        IEnumerable<User> Users();        
        bool Login(LoginViewModel loginViewModel);
        Task<User> GetUserNameAsync(string email);
        
        Task<List<UserViewModel>> GetListUserAsync();
        Task<bool> CreateUserAsync(UserViewModel userCreate);
        Task<UserEditViewModel> GetUserEditAsync(int id);
        Task<bool> EditUserAsync(UserEditViewModel userEdit);
        Task<UserChangePasswordViewModel> GetChangePasswordAsync(int id);
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordModel);
        Task<bool> DeleteUserAsync(int id);
        bool IsExistedEmail(int id, string name);
    }//end of interface
}