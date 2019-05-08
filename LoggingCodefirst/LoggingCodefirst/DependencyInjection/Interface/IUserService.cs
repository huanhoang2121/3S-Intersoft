using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models.Sales;
using LoggingCodefirst.ViewModels.AccountViewModels;
using LoggingCodefirst.ViewModels.UserViewModels;

namespace LoggingCodefirst.DependencyInjection.Interface
{
    public interface IUserService
    {
        IEnumerable<User> Users { get; } 
        
        bool Login(AccountLoginViewModel model);
        Task<User> GetUserNameAsync(string email);
        
        Task<List<UserIndexViewModel>> GetListUserAsync();
        Task<bool> CreateUserAsync(UserCreateViewModel userCreate);
        Task<UserEditViewModel> GetUserEditAsync(int? id);
        Task<bool> EditUserAsync(UserEditViewModel userEdit);
        Task<bool> DeleteUserAsync(int? id);
        Task<UserChangePasswordViewModel> GetChangePasswordAsync(int? id);
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordModel);
    }//end of interface
}