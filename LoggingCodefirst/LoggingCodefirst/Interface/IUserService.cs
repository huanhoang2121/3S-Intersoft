using System.Collections.Generic;
using System.Threading.Tasks;
using LoggingCodefirst.Models;
using LoggingCodefirst.ViewModels;

namespace LoggingCodefirst.Interface
{
    public interface IUserService
    {
        
        #region Public Methods

        /// <summary>
        /// Users
        /// </summary>
        /// <returns>Users</returns>
        IEnumerable<User> Users();   
        
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>Could be Login?</returns>
        Task<bool> LoginAsync(LoginViewModel loginViewModel);
        
        /// <summary>
        /// GetUserAsync
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User</returns>
        Task<User> GetUserByEmailAsync(string email);
        
        /// <summary>
        /// GetListUserAsync
        /// </summary>
        /// <returns>ListUser</returns>
        Task<List<UserViewModel>> GetListUserAsync();
        
        /// <summary>
        /// CreateUserAsync
        /// </summary>
        /// <param name="createViewModel"></param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateUserAsync(UserViewModel createViewModel);
        
        /// <summary>
        /// GetUserEditAsync
        /// </summary>
        /// <param name="id">Userid</param>
        /// <returns>UserEditViewModel</returns>
        Task<UserEditViewModel> GetUserEditAsync(int id);
        
        /// <summary>
        /// EditUserAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditUserAsync(UserEditViewModel editViewModel);
        
        /// <summary>
        /// GetChangePasswordAsync
        /// </summary>
        /// <param name="id">Userid</param>
        /// <returns>UserChangePasswordViewModel</returns>
        Task<UserChangePasswordViewModel> GetChangePasswordAsync(int id);
        
        /// <summary>
        /// ChangePasswordAsync
        /// </summary>
        /// <param name="changePasswordViewModel">UserChangePasswordViewModel</param>
        /// <returns>Could be Changed?</returns>
        Task<bool> ChangePasswordAsync(UserChangePasswordViewModel changePasswordViewModel);
        
        /// <summary>
        /// DeleteUserAsync
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteUserAsync(int id);
        
        /// <summary>
        /// IsExistedEmail
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="email">User email</param>
        /// <returns>ExistedEmail</returns>
        bool IsExistedEmail(int id, string email);
        
        #endregion
        
    }//end of interface
}